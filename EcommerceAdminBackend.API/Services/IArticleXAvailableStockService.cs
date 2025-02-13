using EcommerceAdminBackend.API.Models;
using EcommerceAdminBackend.API.Utilities;

namespace EcommerceAdminBackend.API.Services;

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