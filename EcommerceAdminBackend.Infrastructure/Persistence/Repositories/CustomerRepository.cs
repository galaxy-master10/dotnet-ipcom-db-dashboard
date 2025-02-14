

using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAdminBackend.Infrastructure.Persistence.Repositories;

public class CustomerRepository: ICustomerRepository
{
    private readonly ApplicationDbContext _context;
    
    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllCustomersAsync(int pageNumber, int pageSize)
    {
        return await _context.Customers
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalCustomersCountAsync()
    {
        return await _context.Customers.CountAsync();
    }



        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer?> GetCustomerByCustomerIdAsync(int customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<Customer?> GetCustomerByCustomerContactIdAsync(int customerContactId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerContactId == customerContactId);
        }

        public async Task<Customer?> GetCustomerBySourceIdAsync(string sourceId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.SourceId == sourceId);
        }

        public async Task<Customer?> GetCustomerByVatNumberAsync(string vatNumber)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.VatNumber == vatNumber);
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Customer?> GetCustomerByMobileAsync(string mobile)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Mobile == mobile);
        }

        public async Task<Customer?> GetCustomerByWebAsync(string web)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Web == web);
        }

        public async Task<List<Customer>> GetCustomersByFirstNameAsync(string firstName)
        {
            return await _context.Customers.Where(c => c.FirstName == firstName).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByNameAsync(string name)
        {
            return await _context.Customers.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByLanguageAsync(string language)
        {
            return await _context.Customers.Where(c => c.Language == language).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByAddressStreetAsync(string addressStreet)
        {
            return await _context.Customers.Where(c => c.AddressStreet == addressStreet).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByAddressNumberAsync(string addressNumber)
        {
            return await _context.Customers.Where(c => c.AddressNumber == addressNumber).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByAddressPostalCodeAsync(string addressPostalCode)
        {
            return await _context.Customers.Where(c => c.AddressPostalCode == addressPostalCode).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByAddressCityAsync(string addressCity)
        {
            return await _context.Customers.Where(c => c.AddressCity == addressCity).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByAddressCountryAsync(string addressCountry)
        {
            return await _context.Customers.Where(c => c.AddressCountry == addressCountry).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByCreatedTSAsync(DateTime createdTS)
        {
            return await _context.Customers
                .Where(c => c.CreatedTS.HasValue && c.CreatedTS.Value.Date == createdTS.Date)
                .ToListAsync();
        }

}