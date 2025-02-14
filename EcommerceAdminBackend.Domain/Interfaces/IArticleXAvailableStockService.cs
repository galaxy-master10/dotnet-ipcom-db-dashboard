using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Domain.Interfaces;

public interface IArticleXAvailableStockService
{
    Task<PaginatedResponse<ArticleXAvailableStock>> GetAllAvailableStockAsync(int pageNumber, int pageSize);
    Task<ArticleXAvailableStock?> GetAvailableStockByIdAsync(int articleId, int companyStockLocationId);
    Task<List<ArticleXAvailableStock>> GetStockByArticleIdAsync(int articleId);
    Task<List<ArticleXAvailableStock>> GetStockByCompanyStockLocationIdAsync(int companyStockLocationId);
    Task<List<ArticleXAvailableStock>> GetStockByAvailableStockAsync(decimal availableStock);
    Task<List<ArticleXAvailableStock>> GetStockByMinimumStockAsync(decimal minimumStock);
    Task<List<ArticleXAvailableStock>> GetStockByMaximumStockAsync(decimal maximumStock);
    Task<List<ArticleXAvailableStock>> GetStockByActualStockAsync(decimal actualStock);
    
    
}