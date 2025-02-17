



using EcommerceAdminBackend.Application.Validators.Filters;
using EcommerceAdminBackend.Domain.DTOs.Custom;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly CustomerFilterValidator _filterValidator;

    public CustomerService(
        ICustomerRepository repository,
        CustomerFilterValidator filterValidator)
    {
        _repository = repository;
        _filterValidator = filterValidator;
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<PaginatedResponse<Customer>> GetFilteredAsync(
        CustomerFilterDto filter, int pageNumber = 1, int pageSize = 10)
    {
        _filterValidator.ValidateAndNormalize(filter, pageNumber, pageSize);

        var (items, totalCount) = await _repository.GetFilteredAsync(filter, pageNumber, pageSize);
       
        return new PaginatedResponse<Customer>(
            items,
            pageNumber,
            pageSize,
            totalCount
        );
    }
   
}