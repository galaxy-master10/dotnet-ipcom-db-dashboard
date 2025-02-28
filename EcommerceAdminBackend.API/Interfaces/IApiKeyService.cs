namespace EcommerceAdminBackend.API.Interfaces;

public interface IApiKeyService
{
    Task<string> GenerateApiKeyForUserAsync(string userId);
    Task<bool> ValidateApiKeyAsync(string apiKey, string userId);
    Task<bool> RevokeApiKeyAsync(string userId);
}