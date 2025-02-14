



using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<PaginatedResponse<Customer>> GetAllCustomersAsync(int pageNumber, int pageSize)
    {
        var totalRecords = await _customerRepository.GetTotalCustomersCountAsync();
        var customers = await _customerRepository.GetAllCustomersAsync(pageNumber, pageSize);
        return new PaginatedResponse<Customer>(customers, pageNumber, pageSize, totalRecords);
    }
    
        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<Customer?> GetCustomerByCustomerIdAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByCustomerIdAsync(customerId);
        }

        public async Task<Customer?> GetCustomerByCustomerContactIdAsync(int customerContactId)
        {
            return await _customerRepository.GetCustomerByCustomerContactIdAsync(customerContactId);
        }

        public async Task<Customer?> GetCustomerBySourceIdAsync(string sourceId)
        {
            return await _customerRepository.GetCustomerBySourceIdAsync(sourceId);
        }

        public async Task<Customer?> GetCustomerByVatNumberAsync(string vatNumber)
        {
            return await _customerRepository.GetCustomerByVatNumberAsync(vatNumber);
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            return await _customerRepository.GetCustomerByEmailAsync(email);
        }

        public async Task<Customer?> GetCustomerByMobileAsync(string mobile)
        {
            return await _customerRepository.GetCustomerByMobileAsync(mobile);
        }

        public async Task<Customer?> GetCustomerByWebAsync(string web)
        {
            return await _customerRepository.GetCustomerByWebAsync(web);
        }

        public async Task<List<Customer>> GetCustomersByFirstNameAsync(string firstName)
        {
            return await _customerRepository.GetCustomersByFirstNameAsync(firstName);
        }

        public async Task<List<Customer>> GetCustomersByNameAsync(string name)
        {
            return await _customerRepository.GetCustomersByNameAsync(name);
        }

        public async Task<List<Customer>> GetCustomersByLanguageAsync(string language)
        {
            return await _customerRepository.GetCustomersByLanguageAsync(language);
        }

        public async Task<List<Customer>> GetCustomersByAddressStreetAsync(string addressStreet)
        {
            return await _customerRepository.GetCustomersByAddressStreetAsync(addressStreet);
        }

        public async Task<List<Customer>> GetCustomersByAddressNumberAsync(string addressNumber)
        {
            return await _customerRepository.GetCustomersByAddressNumberAsync(addressNumber);
        }

        public async Task<List<Customer>> GetCustomersByAddressPostalCodeAsync(string addressPostalCode)
        {
            return await _customerRepository.GetCustomersByAddressPostalCodeAsync(addressPostalCode);
        }

        public async Task<List<Customer>> GetCustomersByAddressCityAsync(string addressCity)
        {
            return await _customerRepository.GetCustomersByAddressCityAsync(addressCity);
        }

        public async Task<List<Customer>> GetCustomersByAddressCountryAsync(string addressCountry)
        {
            return await _customerRepository.GetCustomersByAddressCountryAsync(addressCountry);
        }

        public async Task<List<Customer>> GetCustomersByCreatedTSAsync(DateTime createdTS)
        {
            return await _customerRepository.GetCustomersByCreatedTSAsync(createdTS);
        }
}