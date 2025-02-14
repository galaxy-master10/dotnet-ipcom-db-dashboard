using EcommerceAdminBackend.Domain.DTOs;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Application.Services;

public class ArticleXAvailableStockService : IArticleXAvailableStockService
{
    private readonly IArticleXAvailableStockRepository _repository;

    public ArticleXAvailableStockService(IArticleXAvailableStockRepository repository)
    {
        _repository = repository;
    }

    public async Task<ArticleXAvailableStock?> GetAvailableStockByIdAsync(int articleId, int companyStockLocationId)
    {
        return await _repository.GetByIdAsync(articleId, companyStockLocationId);
    }

    public async Task<PaginatedResponse<ArticleXAvailableStock>> GetFilteredAsync(
        ArticleXAvailableStockFilterDto filter, int pageNumber = 1, int pageSize = 10)
    {
        var (items, totalCount) = await _repository.GetFilteredAsync(filter, pageNumber, pageSize);
        
        return new PaginatedResponse<ArticleXAvailableStock>(
            items,
            pageNumber,
            pageSize,
            totalCount
        );
    }
}