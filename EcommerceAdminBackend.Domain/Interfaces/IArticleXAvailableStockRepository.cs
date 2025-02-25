using EcommerceAdminBackend.Domain.DTOs;
using EcommerceAdminBackend.Domain.Entities;

namespace EcommerceAdminBackend.Domain.Interfaces;


public interface IArticleXAvailableStockRepository
{
    IQueryable<ArticleXAvailableStock> GetQueryable();
    Task<ArticleXAvailableStock?> GetByIdAndLocationIdAsync(int articleId, int companyStockLocationId);
    Task<ArticleXAvailableStock?> GetByIdAsync(int articleId);
    Task<(List<ArticleXAvailableStock> Items, int TotalCount)> GetFilteredAsync(
        ArticleXAvailableStockFilterDto filter, int pageNumber, int pageSize);
}