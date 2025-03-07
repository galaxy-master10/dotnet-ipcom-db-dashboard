using Azure.Security.KeyVault.Secrets;
using EcommerceAdminBackend.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAdminBackend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize] 
public class ApiKeyController : ControllerBase
{
    private readonly IApiKeyService _apiKeyService;
    private readonly SecretClient _secretClient;

    public ApiKeyController(IApiKeyService apiKeyService, SecretClient secretClient)
    {
        _apiKeyService = apiKeyService;
        _secretClient = secretClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetApiKey()
    {
        try
        {
            
            var userId = User.Identity?.Name ?? "Unknown";
            var isAuthenticated = User.Identity?.IsAuthenticated ?? false;
        
            if (!isAuthenticated)
            {
                return Unauthorized(new { message = "User is not authenticated" });
            }
        
            try
            {
                var apiKeyExists = await _apiKeyService.IsApiKeyValidAsync();
                if (!apiKeyExists)
                {
                    return NotFound(new { 
                        message = "No valid API key found. Please generate one first."
                    });
                }
                
                var apiKey = await _apiKeyService.GetApiKeyAsync();
                var expirationDate = await _apiKeyService.GetApiKeyExpirationAsync();
                
                // Calculate remaining time
                var remainingTime = expirationDate - DateTime.UtcNow;
                var remainingDays = Math.Round(remainingTime.TotalDays, 1);
                
                return Ok(new { 
                    apiKey = apiKey,
                    expiresAt = expirationDate,
                    remainingDays = remainingDays,
                    user = userId
                });
            }
            catch (Exception ex)
            {
                
                if (ex.Message.Contains("not found") || ex.Message.Contains("Failed to retrieve API key"))
                {
                    return NotFound(new { 
                        message = "API key not found. Please generate one first.",
                        error = ex.Message
                    });
                }
            
                throw; 
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { 
                error = "Failed to get API key",
                message = ex.Message,
                innerException = ex.InnerException?.Message
            });
        }
    }
    [HttpGet("validate")]
    public async Task<IActionResult> ValidateApiKey()
    {
        try
        {
            var isValid = await _apiKeyService.IsApiKeyValidAsync();
            var expirationDate = await _apiKeyService.GetApiKeyExpirationAsync();
            var remainingTime = expirationDate - DateTime.UtcNow;
            
            return Ok(new {
                isValid = isValid,
                expiresAt = expirationDate,
                remainingDays = Math.Round(remainingTime.TotalDays, 1),
                remainingHours = Math.Round(remainingTime.TotalHours, 1)
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {
                error = "Failed to validate API key",
                message = ex.Message
            });
        }
    }
    
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateApiKey([FromQuery] int expirationDays = 30)
    {
        var (apiKey, expiresAt) = await _apiKeyService.GenerateNewApiKeyAsync(expirationDays);
            
        return Ok(new { 
            apiKey = apiKey,
            expiresAt = expiresAt,
            message = "New API key generated successfully"
        });
    }
    [HttpGet("test-keyvault")]
    public async Task<IActionResult> TestKeyVault()
    {
        try
        {
           
            var secrets =  _secretClient.GetPropertiesOfSecretsAsync();
            var secretNames = new List<string>();
        
            await foreach (var secret in secrets)
            {
                secretNames.Add(secret.Name);
            }
        
            return Ok(new { 
                message = "Key Vault connection successful", 
                secretCount = secretNames.Count,
                secretsExist = secretNames.Any(),
                secretNames = secretNames
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { 
                error = "Key Vault connection failed", 
                message = ex.Message,
                innerException = ex.InnerException?.Message
            });
        }
    }
}