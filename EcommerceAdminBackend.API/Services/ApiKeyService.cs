using System.Security.Cryptography;
using Azure.Security.KeyVault.Secrets;
using EcommerceAdminBackend.API.Interfaces;

namespace EcommerceAdminBackend.API.Services;

public class ApiKeyService : IApiKeyService
{
    private readonly SecretClient _secretClient;

    public ApiKeyService(SecretClient secretClient)
    {
        _secretClient = secretClient;
    }

    public async Task<string> GenerateApiKeyForUserAsync(string userId)
    {
        // Generate a unique API key using a secure random generator
        var apiKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            
        // Store the API key in Azure Key Vault with user ID as part of the key name
        // Format: "apikey-{userId}"
        await _secretClient.SetSecretAsync($"apikey-{userId}", apiKey);
            
        return apiKey;
    }

    public async Task<bool> ValidateApiKeyAsync(string apiKey, string userId)
    {
        try
        {
            // Retrieve the stored API key from Azure Key Vault
            var secret = await _secretClient.GetSecretAsync($"apikey-{userId}");
            var storedApiKey = secret.Value.Value;
                
            // Compare the provided API key with the stored one
            return apiKey == storedApiKey;
        }
        catch (Exception)
        {
            // If the API key doesn't exist or any other error occurs
            return false;
        }
    }

    public async Task<bool> RevokeApiKeyAsync(string userId)
    {
        try
        {
            // Delete the API key from the Key Vault
            await _secretClient.StartDeleteSecretAsync($"apikey-{userId}");
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
