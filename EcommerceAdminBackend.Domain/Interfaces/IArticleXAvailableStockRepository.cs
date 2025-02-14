using EcommerceAdminBackend.Domain.Entities;

namespace EcommerceAdminBackend.Domain.Interfaces;

public interface IArticleXAvailableStockRepository
{
    // ✅ Get all Available Stock Entries
    Task<List<ArticleXAvailableStock>> GetAllAvailableStockAsync(int pageNumber, int pageSize);
    Task<int> GetTotalAvailableStockCountAsync();

    // ✅ Get by Composite Key (ArticleId & CompanyStockLocationId)
    Task<ArticleXAvailableStock?> GetAvailableStockByIdAsync(int articleId, int companyStockLocationId);

    // ✅ Get by Article ID
    Task<List<ArticleXAvailableStock>> GetStockByArticleIdAsync(int articleId);

    // ✅ Get by Company Stock Location ID
    Task<List<ArticleXAvailableStock>> GetStockByCompanyStockLocationIdAsync(int companyStockLocationId);

    // ✅ Get by Stock Levels
    Task<List<ArticleXAvailableStock>> GetStockByAvailableStockAsync(decimal availableStock);
    Task<List<ArticleXAvailableStock>> GetStockByMinimumStockAsync(decimal minimumStock);
    Task<List<ArticleXAvailableStock>> GetStockByMaximumStockAsync(decimal maximumStock);
    Task<List<ArticleXAvailableStock>> GetStockByActualStockAsync(decimal actualStock);

}