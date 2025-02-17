
using EcommerceAdminBackend.Domain.DTOs.Filters;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Domain.Interfaces;

public interface IArticlePackagingBreakdownService
{
    Task<ArticlePackagingBreakdown?> GetByIdAsync(int id);
    Task<PaginatedResponse<ArticlePackagingBreakdown>> GetFilteredAsync(
        ArticlePackagingBreakdownFilterDto filter, int pageNumber = 1, int pageSize = 10);

    
}