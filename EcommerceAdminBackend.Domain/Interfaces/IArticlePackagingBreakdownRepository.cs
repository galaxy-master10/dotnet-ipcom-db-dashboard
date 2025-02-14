
using EcommerceAdminBackend.Domain.Entities;

namespace EcommerceAdminBackend.Domain.Interfaces;

public interface IArticlePackagingBreakdownRepository
{
// ✅ Get all Article Packaging Breakdowns
    Task<List<ArticlePackagingBreakdown>> GetAllArticlePackagingBreakdownsAsync(int pageNumber, int pageSize);
    Task<int> GetTotalArticlePackagingBreakdownsCountAsync();

    // ✅ Get by ID
    Task<ArticlePackagingBreakdown?> GetArticlePackagingBreakdownByIdAsync(int id);

    // ✅ Get by Article ID
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByArticleIdAsync(int articleId);

    // ✅ Get by Units & Conversion Factors
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromUnitAsync(string fromUnit);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToUnitAsync(string toUnit);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromUnitIdAsync(int fromUnitId);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToUnitIdAsync(int toUnitId);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromFactorAsync(decimal fromFactor);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToFactorAsync(decimal toFactor);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByCubesAsync(decimal cubes);

    // ✅ Get by Status Flags
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByStatusInUseAsync(bool statusInUse);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByIsERPAsync(bool isERP);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByIsMinimumPackagingAsync(bool isMinimumPackaging);
}