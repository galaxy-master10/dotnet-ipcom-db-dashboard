namespace EcommerceAdminBackend.API.Interfaces;

public interface IApiKeyService
{
    Task<string> GetApiKeyAsync();
    Task<DateTime> GetApiKeyExpirationAsync();
    Task<bool> IsApiKeyValidAsync();
    Task<(string apiKey, DateTime expiresAt)> GenerateNewApiKeyAsync(int expirationDays = 30);

}