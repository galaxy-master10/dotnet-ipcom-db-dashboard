

using EcommerceAdminBackend.Domain.DTOs.Custom;
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

    public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<(List<Customer> Items, int TotalCount)> GetFilteredAsync(
            CustomerFilterDto filter, int pageNumber, int pageSize)
        {
            var query = _context.Customers.AsQueryable();

            // Apply filters
            if (filter.Id.HasValue)
                query = query.Where(x => x.Id == filter.Id);

            if (filter.CustomerId.HasValue)
                query = query.Where(x => x.CustomerId == filter.CustomerId);

            if (filter.CustomerContactId.HasValue)
                query = query.Where(x => x.CustomerContactId == filter.CustomerContactId);

            if (!string.IsNullOrEmpty(filter.SourceId))
                query = query.Where(x => x.SourceId == filter.SourceId);

            if (!string.IsNullOrEmpty(filter.CustomerName))
                query = query.Where(x => x.CustomerName.Contains(filter.CustomerName));

            if (!string.IsNullOrEmpty(filter.AddressStreet))
                query = query.Where(x => x.AddressStreet.Contains(filter.AddressStreet));

            if (!string.IsNullOrEmpty(filter.AddressNumber))
                query = query.Where(x => x.AddressNumber == filter.AddressNumber);

            if (!string.IsNullOrEmpty(filter.AddressPostalCode))
                query = query.Where(x => x.AddressPostalCode == filter.AddressPostalCode);

            if (!string.IsNullOrEmpty(filter.AddressCity))
                query = query.Where(x => x.AddressCity.Contains(filter.AddressCity));

            if (!string.IsNullOrEmpty(filter.AddressCountry))
                query = query.Where(x => x.AddressCountry == filter.AddressCountry);

            if (!string.IsNullOrEmpty(filter.Web))
                query = query.Where(x => x.Web == filter.Web);

            if (!string.IsNullOrEmpty(filter.VatNumber))
                query = query.Where(x => x.VatNumber == filter.VatNumber);

            if (!string.IsNullOrEmpty(filter.FirstName))
                query = query.Where(x => x.FirstName.Contains(filter.FirstName));

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(x => x.Name.Contains(filter.Name));

            if (!string.IsNullOrEmpty(filter.Email))
                query = query.Where(x => x.Email == filter.Email);

            if (!string.IsNullOrEmpty(filter.Language))
                query = query.Where(x => x.Language == filter.Language);

            if (!string.IsNullOrEmpty(filter.Mobile))
                query = query.Where(x => x.Mobile == filter.Mobile);

            if (filter.CreatedTS.HasValue)
                query = query.Where(x => x.CreatedTS.HasValue && 
                    x.CreatedTS.Value.Date == filter.CreatedTS.Value.Date);

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            // Apply pagination
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    
}