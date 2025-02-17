
using EcommerceAdminBackend.Domain.DTOs.Filters;
using EcommerceAdminBackend.Domain.Entities;

namespace EcommerceAdminBackend.Domain.Interfaces;

public interface IArticlePackagingBreakdownRepository
{
    Task<ArticlePackagingBreakdown?> GetByIdAsync(int id);
    Task<(List<ArticlePackagingBreakdown> Items, int TotalCount)> GetFilteredAsync(
        ArticlePackagingBreakdownFilterDto filter, int pageNumber, int pageSize);

}