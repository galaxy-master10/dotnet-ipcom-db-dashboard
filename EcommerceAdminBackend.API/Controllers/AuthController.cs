using EcommerceAdminBackend.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace EcommerceAdminBackend.API.Controllers;

[ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IApiKeyService _apiKeyService;

        public AuthController(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        /// <summary>
        /// Endpoint to generate a new API key for the authenticated user
        /// Requires Azure AD authentication
        /// </summary>
        [Authorize]
        [HttpGet("getapikey")]
        public async Task<IActionResult> GetApiKey()
        {
            // Get the user ID from the claims provided by Azure AD
            var userId = User.GetObjectId(); // Microsoft.Identity.Web extension method
            
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(new { error = "User ID not found in token claims" });
            }
            
            // Generate a new API key for the user and store it in Azure Key Vault
            var apiKey = await _apiKeyService.GenerateApiKeyForUserAsync(userId);
            
            return Ok(new { apiKey });
        }

        /// <summary>
        /// Endpoint to revoke the current API key for a user
        /// Requires Azure AD authentication
        /// </summary>
        [Authorize]
        [HttpDelete("revokeapikey")]
        public async Task<IActionResult> RevokeApiKey()
        {
            var userId = User.GetObjectId();
            
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(new { error = "User ID not found in token claims" });
            }
            
            var result = await _apiKeyService.RevokeApiKeyAsync(userId);
            
            if (result)
            {
                return Ok(new { message = "API key revoked successfully" });
            }
            
            return BadRequest(new { error = "Failed to revoke API key" });
        }

        /// <summary>
        /// Endpoint to verify authentication status
        /// </summary>
        [HttpGet("verify")]
        public IActionResult VerifyAuthentication()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.GetObjectId();
                var name = User.Identity.Name;
                
                return Ok(new { 
                    isAuthenticated = true, 
                    userId, 
                    username = name,
                    claims = User.Claims.Select(c => new { c.Type, c.Value })
                });
            }
            
            return Ok(new { isAuthenticated = false });
        }
    }