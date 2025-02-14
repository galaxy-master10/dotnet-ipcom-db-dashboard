
using EcommerceAdminBackend.Domain.DTOs.Custom;
using EcommerceAdminBackend.Domain.Entities;

namespace EcommerceAdminBackend.Domain.Interfaces;

public interface ICustomerRepository
{
 
        Task<Customer?> GetByIdAsync(int id);
        Task<(List<Customer> Items, int TotalCount)> GetFilteredAsync(
            CustomerFilterDto filter, int pageNumber, int pageSize);
    
}
    
