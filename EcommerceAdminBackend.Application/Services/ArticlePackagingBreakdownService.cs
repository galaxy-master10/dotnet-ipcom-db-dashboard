
using EcommerceAdminBackend.Domain.DTOs.Filters;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Application.Services;

public class ArticlePackagingBreakdownService : IArticlePackagingBreakdownService
{
    private readonly IArticlePackagingBreakdownRepository _repository;

    public ArticlePackagingBreakdownService(IArticlePackagingBreakdownRepository repository)
    {
        _repository = repository;
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
        // Validate input
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;

        // Validate filter ranges
        if (filter != null)
        {
            ValidateRanges(filter);
        }

        var (items, totalCount) = await _repository.GetFilteredAsync(filter, pageNumber, pageSize);

        return new PaginatedResponse<ArticlePackagingBreakdown>(
            items,
            pageNumber,
            pageSize,
            totalCount
        );
    }

    private void ValidateRanges(ArticlePackagingBreakdownFilterDto filter)
    {
        if (filter.MinFromFactor.HasValue && filter.MaxFromFactor.HasValue && 
            filter.MinFromFactor > filter.MaxFromFactor)
            (filter.MinFromFactor, filter.MaxFromFactor) = (filter.MaxFromFactor, filter.MinFromFactor);

        if (filter.MinToFactor.HasValue && filter.MaxToFactor.HasValue && 
            filter.MinToFactor > filter.MaxToFactor)
            (filter.MinToFactor, filter.MaxToFactor) = (filter.MaxToFactor, filter.MinToFactor);

        if (filter.MinCubes.HasValue && filter.MaxCubes.HasValue && 
            filter.MinCubes > filter.MaxCubes)
            (filter.MinCubes, filter.MaxCubes) = (filter.MaxCubes, filter.MinCubes);
    }
}