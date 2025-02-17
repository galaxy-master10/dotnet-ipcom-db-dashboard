
using EcommerceAdminBackend.Application.Validators.Filters;
using EcommerceAdminBackend.Domain.DTOs.Filters;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Application.Services;

public class ArticlePackagingBreakdownService : IArticlePackagingBreakdownService
{
    private readonly IArticlePackagingBreakdownRepository _repository;
    private readonly ArticlePackagingBreakdownFilterValidator _filterValidator;

    public ArticlePackagingBreakdownService(
        IArticlePackagingBreakdownRepository repository,
        ArticlePackagingBreakdownFilterValidator filterValidator)
    {
        _repository = repository;
        _filterValidator = filterValidator;
    }


    public async Task<ArticlePackagingBreakdown?> GetByIdAsync(int id)
    {
        if (id <= 0)
            return null;

        return await _repository.GetByIdAsync(id);
    }

    public async Task<PaginatedResponse<ArticlePackagingBreakdown>> GetFilteredAsync(
        ArticlePackagingBreakdownFilterDto filter, int pageNumber = 1, int pageSize = 10)
    {
        // Validate pagination
        pageNumber = Math.Max(1, pageNumber);
        pageSize = Math.Max(1, Math.Min(pageSize, 100)); // Add max limit

        // Validate filter
        _filterValidator.ValidateAndNormalize(filter);

        var (items, totalCount) = await _repository.GetFilteredAsync(filter, pageNumber, pageSize);

        return new PaginatedResponse<ArticlePackagingBreakdown>(
            items,
            pageNumber,
            pageSize,
            totalCount
        );
    }
    

   
}