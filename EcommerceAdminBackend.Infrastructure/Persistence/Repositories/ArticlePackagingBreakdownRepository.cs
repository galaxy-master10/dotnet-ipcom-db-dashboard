
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Infrastructure.Persistence.Context;
using EcommerceAdminBackend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAdminBackend.Infrastructure.Persistence.Repositories;

public class ArticlePackagingBreakdownRepository : IArticlePackagingBreakdownRepository
{
    private readonly ApplicationDbContext _context;
    
    public ArticlePackagingBreakdownRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<ArticlePackagingBreakdown>> GetAllArticlePackagingBreakdownsAsync(int pageNumber, int pageSize)
    {
        return await _context.ArticlePackagingBreakdowns
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalArticlePackagingBreakdownsCountAsync()
    {
        return await _context.ArticlePackagingBreakdowns.CountAsync();
    }

    public async Task<ArticlePackagingBreakdown?> GetArticlePackagingBreakdownByIdAsync(int id)
    {
        return await _context.ArticlePackagingBreakdowns.FindAsync(id);
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByArticleIdAsync(int articleId)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.ArticleId == articleId).ToListAsync();
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromUnitAsync(string fromUnit)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.FromUnit == fromUnit).ToListAsync();
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToUnitAsync(string toUnit)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.ToUnit == toUnit).ToListAsync();
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromUnitIdAsync(int fromUnitId)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.FromUnitId == fromUnitId).ToListAsync();
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToUnitIdAsync(int toUnitId)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.ToUnitId == toUnitId).ToListAsync();
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByFromFactorAsync(decimal fromFactor)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.FromFactor == fromFactor).ToListAsync();
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByToFactorAsync(decimal toFactor)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.ToFactor == toFactor).ToListAsync();
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByCubesAsync(decimal cubes)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.Cubes == cubes).ToListAsync();
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByStatusInUseAsync(bool statusInUse)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.StatusInUse == statusInUse).ToListAsync();
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByIsERPAsync(bool isERP)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.IsERP == isERP).ToListAsync();
    }

    public async Task<List<ArticlePackagingBreakdown>> GetBreakdownsByIsMinimumPackagingAsync(bool isMinimumPackaging)
    {
        return await _context.ArticlePackagingBreakdowns.Where(a => a.IsMinimumPackaging == isMinimumPackaging).ToListAsync();
    }
}