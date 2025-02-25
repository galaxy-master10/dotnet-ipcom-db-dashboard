// IArticleXAvailableStockService interface
using EcommerceAdminBackend.Domain.DTOs;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Domain.Interfaces;

public interface IArticleXAvailableStockService
{
    Task<ArticleXAvailableStock?> GetAvailableStockByIdAndLocationIdAsync(int articleId, int companyStockLocationId);
    Task<ArticleXAvailableStock?> GetAvailableStockByIdAsync(int articleId);
    Task<PaginatedResponse<ArticleXAvailableStock>> GetFilteredAsync(
        ArticleXAvailableStockFilterDto filter, int pageNumber = 1, int pageSize = 10);
}