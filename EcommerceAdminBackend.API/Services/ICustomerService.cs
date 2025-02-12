using EcommerceAdminBackend.API.Models;

namespace EcommerceAdminBackend.API.Services;

public interface ICustomerService
{
    
    Task<List<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(int id);
    Task<Customer?> GetCustomerByCustomerIdAsync(int customerId);
    Task<Customer?> GetCustomerByCustomerContactIdAsync(int customerContactId);
    Task<Customer?> GetCustomerBySourceIdAsync(string sourceId);
    Task<Customer?> GetCustomerByVatNumberAsync(string vatNumber);
    Task<Customer?> GetCustomerByEmailAsync(string email);
    Task<Customer?> GetCustomerByMobileAsync(string mobile);
    Task<Customer?> GetCustomerByWebAsync(string web);
    Task<List<Customer>> GetCustomersByFirstNameAsync(string firstName);
    Task<List<Customer>> GetCustomersByNameAsync(string name);
    Task<List<Customer>> GetCustomersByLanguageAsync(string language);
    Task<List<Customer>> GetCustomersByAddressStreetAsync(string addressStreet);
    Task<List<Customer>> GetCustomersByAddressNumberAsync(string addressNumber);
    Task<List<Customer>> GetCustomersByAddressPostalCodeAsync(string addressPostalCode);
    Task<List<Customer>> GetCustomersByAddressCityAsync(string addressCity);
    Task<List<Customer>> GetCustomersByAddressCountryAsync(string addressCountry);
    Task<List<Customer>> GetCustomersByCreatedTSAsync(DateTime createdTS);
    
    
}