



using EcommerceAdminBackend.Domain.DTOs.Custom;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<PaginatedResponse<Customer>> GetFilteredAsync(
        CustomerFilterDto filter, int pageNumber = 1, int pageSize = 10)
    {
        var (items, totalCount) = await _repository.GetFilteredAsync(filter, pageNumber, pageSize);
        
        return new PaginatedResponse<Customer>(
            items,
            pageNumber,
            pageSize,
            totalCount
        );
    }
   
}