
using EcommerceAdminBackend.Domain.DTOs;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAdminBackend.Infrastructure.Persistence.Repositories;

public class ArticleXAvailableStockRepository : IArticleXAvailableStockRepository
{
    private readonly ApplicationDbContext _context;
    
    public ArticleXAvailableStockRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<ArticleXAvailableStock> GetQueryable()
    {
        return _context.ArticleXAvailableStocks;
    }

    public async Task<ArticleXAvailableStock?> GetByIdAndLocationIdAsync(int articleId, int companyStockLocationId)
    {
        return await _context.ArticleXAvailableStocks.FindAsync(articleId, companyStockLocationId);
    }

    public async Task<ArticleXAvailableStock?> GetByIdAsync(int articleId)
    {
        return await _context.ArticleXAvailableStocks.FindAsync(articleId);
    }

    public async Task<(List<ArticleXAvailableStock> Items, int TotalCount)> GetFilteredAsync(
        ArticleXAvailableStockFilterDto filter, int pageNumber, int pageSize)
    {
        var query = _context.ArticleXAvailableStocks.AsQueryable();

        // Apply filters
        if (filter.ArticleId.HasValue)
            query = query.Where(x => x.ArticleId == filter.ArticleId);

        if (filter.CompanyStockLocationId.HasValue)
            query = query.Where(x => x.CompanyStockLocationId == filter.CompanyStockLocationId);

        if (filter.MinAvailableStock.HasValue)
            query = query.Where(x => x.AvailableStock >= filter.MinAvailableStock);

        if (filter.MaxAvailableStock.HasValue)
            query = query.Where(x => x.AvailableStock <= filter.MaxAvailableStock);

        if (filter.MinimumStock.HasValue)
            query = query.Where(x => x.MinimumStock == filter.MinimumStock);

        if (filter.MaximumStock.HasValue)
            query = query.Where(x => x.MaximumStock == filter.MaximumStock);

        if (filter.ActualStock.HasValue)
            query = query.Where(x => x.ActualStock == filter.ActualStock);

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply pagination
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}