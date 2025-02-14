


using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Application.Services;

public class ArticleXAvailableStockService : IArticleXAvailableStockService
{
    private readonly IArticleXAvailableStockRepository _articleXAvailableStockRepository;
    
    public ArticleXAvailableStockService(IArticleXAvailableStockRepository articleXAvailableStockRepository)
    {
        _articleXAvailableStockRepository = articleXAvailableStockRepository;
    }
    


    public async Task<PaginatedResponse<ArticleXAvailableStock>> GetAllAvailableStockAsync(int pageNumber, int pageSize)
    {
        var totalAvailableStockCount = await _articleXAvailableStockRepository.GetTotalAvailableStockCountAsync();
        var availableStock = await _articleXAvailableStockRepository.GetAllAvailableStockAsync(pageNumber, pageSize);
        return new PaginatedResponse<ArticleXAvailableStock>(availableStock, totalAvailableStockCount, pageNumber, pageSize);
    }

    public async Task<ArticleXAvailableStock?> GetAvailableStockByIdAsync(int articleId, int companyStockLocationId)
    {
        return await _articleXAvailableStockRepository.GetAvailableStockByIdAsync(articleId, companyStockLocationId);
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByArticleIdAsync(int articleId)
    {
        return await _articleXAvailableStockRepository.GetStockByArticleIdAsync(articleId);
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByCompanyStockLocationIdAsync(int companyStockLocationId)
    {
        return await _articleXAvailableStockRepository.GetStockByCompanyStockLocationIdAsync(companyStockLocationId);
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByAvailableStockAsync(decimal availableStock)
    {
        return await _articleXAvailableStockRepository.GetStockByAvailableStockAsync(availableStock);
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByMinimumStockAsync(decimal minimumStock)
    {
        return await _articleXAvailableStockRepository.GetStockByMinimumStockAsync(minimumStock);
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByMaximumStockAsync(decimal maximumStock)
    {
        return await _articleXAvailableStockRepository.GetStockByMaximumStockAsync(maximumStock);
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByActualStockAsync(decimal actualStock)
    {
        return await _articleXAvailableStockRepository.GetStockByActualStockAsync(actualStock);
    }
}