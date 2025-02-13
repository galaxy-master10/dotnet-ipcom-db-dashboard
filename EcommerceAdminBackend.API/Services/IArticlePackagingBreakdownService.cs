using EcommerceAdminBackend.API.Models;
using EcommerceAdminBackend.API.Utilities;

namespace EcommerceAdminBackend.API.Services;

public interface IArticlePackagingBreakdownService
{
    Task<PaginatedResponse<ArticlePackagingBreakdown>> GetAllArticlePackagingBreakdownAsync(int pageNumber, int pageSize);
    Task<ArticlePackagingBreakdown?> GetArticlePackagingBreakdownByIdAsync(int id);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByArticleIdAsync(int articleId);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromUnitAsync(string fromUnit);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToUnitAsync(string toUnit);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromUnitIdAsync(int fromUnitId);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToUnitIdAsync(int toUnitId);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromFactorAsync(decimal fromFactor);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToFactorAsync(decimal toFactor);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByCubesAsync(decimal cubes);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByStatusInUseAsync(bool statusInUse);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByIsERPAsync(bool isERP);
    Task<List<ArticlePackagingBreakdown>> GetBreakdownsByIsMinimumPackagingAsync(bool isMinimumPackaging);
    
    
    
}