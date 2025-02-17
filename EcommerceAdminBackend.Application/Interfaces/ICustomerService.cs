
using EcommerceAdminBackend.Domain.DTOs.Custom;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Domain.Interfaces;

public interface ICustomerService
{
    Task<Customer?> GetByIdAsync(int id);
    Task<PaginatedResponse<Customer>> GetFilteredAsync(
        CustomerFilterDto filter, int pageNumber = 1, int pageSize = 10);
    
}