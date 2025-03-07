using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets;
using EcommerceAdminBackend.API.Interfaces;

namespace EcommerceAdminBackend.API.Services;

public class ApiKeyService : IApiKeyService
{
    private readonly SecretClient _secretClient;
    private const string ApiKeyName = "ApplicationApiKey";
    private const int DefaultExpirationDays = 30;

    public ApiKeyService(SecretClient secretClient)
    {
        _secretClient = secretClient;
    }

    public async Task<string> GetApiKeyAsync()
    {
        try 
        {
            var secret = await _secretClient.GetSecretAsync(ApiKeyName);
            return secret.Value.Value;
        }
        catch (Exception ex)
        {
           
            throw new Exception("Failed to retrieve API key", ex);
        }
    }

    public async Task<DateTime> GetApiKeyExpirationAsync()
    {
        var secret = await _secretClient.GetSecretAsync(ApiKeyName);
        return secret.Value.Properties.ExpiresOn?.DateTime ?? DateTime.UtcNow.AddDays(1);
    }
    
    public async Task<bool> IsApiKeyValidAsync()
    {
        try
        {
            var expirationDate = await GetApiKeyExpirationAsync();
            return expirationDate > DateTime.UtcNow;
        }
        catch
        {
            return false;
        }
    }
    public async Task<(string apiKey, DateTime expiresAt)> GenerateNewApiKeyAsync(int expirationDays = DefaultExpirationDays)
    {
  
        byte[] keyBytes = new byte[24]; 
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(keyBytes);
        }
        string apiKey = Convert.ToBase64String(keyBytes);
            
        
        DateTime expirationDate = DateTime.UtcNow.AddDays(expirationDays);
        
        
        var secret = new KeyVaultSecret(ApiKeyName, apiKey);
        
        
        secret.Properties.ExpiresOn = expirationDate;
        
        
        await _secretClient.SetSecretAsync(secret);
        
        return (apiKey, expirationDate);
    }
}