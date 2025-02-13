using EcommerceAdminBackend.API.Models;
using EcommerceAdminBackend.API.Repositories;
using EcommerceAdminBackend.API.Utilities;

namespace EcommerceAdminBackend.API.Services;

public class ArticlePackagingBreakdownService : IArticlePackagingBreakdownService
{
    private readonly IArticlePackagingBreakdownRepository _articlePackagingBreakdownRepository;

    public ArticlePackagingBreakdownService(IArticlePackagingBreakdownRepository articlePackagingBreakdownRepository)
    {
        _articlePackagingBreakdownRepository = articlePackagingBreakdownRepository;
    }

    public async Task<PaginatedResponse<ArticlePackagingBreakdown>> GetAllArticlePackagingBreakdownAsync(int pageNumber, int pageSize)
    {
        var totalBreakdowns = await _articlePackagingBreakdownRepository.GetTotalArticlePackagingBreakdownsCountAsync();
        var breakdowns = await _articlePackagingBreakdownRepository.GetAllArticlePackagingBreakdownsAsync(pageNumber, pageSize);
        return new PaginatedResponse<ArticlePackagingBreakdown>(breakdowns, pageNumber, pageSize, totalBreakdowns);
    }

    public async Task<ArticlePackagingBreakdown?> GetArticlePackagingBreakdownByIdAsync(int id)
    {
        return await _articlePackagingBreakdownRepository.GetArticlePackagingBreakdownByIdAsync(id);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByArticleIdAsync(int articleId)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByArticleIdAsync(articleId);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromUnitAsync(string fromUnit)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByFromUnitAsync(fromUnit);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToUnitAsync(string toUnit)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByToUnitAsync(toUnit);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromUnitIdAsync(int fromUnitId)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByFromUnitIdAsync(fromUnitId); 
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToUnitIdAsync(int toUnitId)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByToUnitIdAsync(toUnitId);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromFactorAsync(decimal fromFactor)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByFromFactorAsync(fromFactor);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToFactorAsync(decimal toFactor)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByToFactorAsync(toFactor);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByCubesAsync(decimal cubes)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByCubesAsync(cubes);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByStatusInUseAsync(bool statusInUse)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByStatusInUseAsync(statusInUse);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByIsERPAsync(bool isERP)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByIsERPAsync(isERP);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByIsMinimumPackagingAsync(bool isMinimumPackaging)
    {
        return await _articlePackagingBreakdownRepository.GetBreakdownsByIsMinimumPackagingAsync(isMinimumPackaging);
    }
}