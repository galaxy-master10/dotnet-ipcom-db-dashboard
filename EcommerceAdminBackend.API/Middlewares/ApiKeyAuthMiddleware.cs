using System.Text.Json;
using EcommerceAdminBackend.API.Interfaces;
using Microsoft.Identity.Web;

namespace EcommerceAdminBackend.API.Middlewares;
 public class ApiKeyAuthMiddleware : IMiddleware
    {
        private const string ApiKeyHeaderName = "X-API-Key";
        private readonly IApiKeyService _apiKeyService;

        public ApiKeyAuthMiddleware(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Skip validation for authentication endpoints or non-API paths
            if (context.Request.Path.StartsWithSegments("/api/auth") || 
                !context.Request.Path.StartsWithSegments("/api"))
            {
                await next(context);
                return;
            }

            // Check if the user is authenticated via JWT
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await WriteJsonResponse(context, new { error = "Authentication required" });
                return;
            }

            // Check for API key in headers
            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyValues))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await WriteJsonResponse(context, new { error = "API key is required" });
                return;
            }

            string apiKey = apiKeyValues.ToString();
            string userId = context.User.GetObjectId(); // Microsoft.Identity.Web extension method

            // No user ID found in the token claims
            if (string.IsNullOrEmpty(userId))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await WriteJsonResponse(context, new { error = "Invalid token claims" });
                return;
            }

            // Validate API key against Key Vault
            bool isValidApiKey = await _apiKeyService.ValidateApiKeyAsync(apiKey, userId);

            if (!isValidApiKey)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await WriteJsonResponse(context, new { error = "Invalid API key" });
                return;
            }

            // API key is valid, continue the pipeline
            await next(context);
        }

        private static async Task WriteJsonResponse(HttpContext context, object response)
        {
            context.Response.ContentType = "application/json";
            await JsonSerializer.SerializeAsync(context.Response.Body, response);
        }
    }