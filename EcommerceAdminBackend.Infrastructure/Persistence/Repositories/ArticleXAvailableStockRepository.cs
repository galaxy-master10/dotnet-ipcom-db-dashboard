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


    public async Task<List<ArticleXAvailableStock>> GetAllAvailableStockAsync(int pageNumber, int pageSize)
    {
        return await _context.ArticleXAvailableStocks
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalAvailableStockCountAsync()
    {
        return await _context.ArticleXAvailableStocks.CountAsync();
    }

    public async Task<ArticleXAvailableStock?> GetAvailableStockByIdAsync(int articleId, int companyStockLocationId)
    {
        return await _context.ArticleXAvailableStocks.FindAsync(articleId, companyStockLocationId);
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByArticleIdAsync(int articleId)
    {
        return await _context.ArticleXAvailableStocks.Where(a => a.ArticleId == articleId).ToListAsync();
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByCompanyStockLocationIdAsync(int companyStockLocationId)
    {
        return await _context.ArticleXAvailableStocks.Where(a => a.CompanyStockLocationId == companyStockLocationId).ToListAsync();
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByAvailableStockAsync(decimal availableStock)
    {
        return await _context.ArticleXAvailableStocks.Where(a => a.AvailableStock == availableStock).ToListAsync();
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByMinimumStockAsync(decimal minimumStock)
    {
        return await _context.ArticleXAvailableStocks.Where(a => a.MinimumStock == minimumStock).ToListAsync();
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByMaximumStockAsync(decimal maximumStock)
    {
        return await _context.ArticleXAvailableStocks.Where(a => a.MaximumStock == maximumStock).ToListAsync();
    }

    public async Task<List<ArticleXAvailableStock>> GetStockByActualStockAsync(decimal actualStock)
    {
        return await _context.ArticleXAvailableStocks.Where(a => a.ActualStock == actualStock).ToListAsync();
    }
}