
using EcommerceAdminBackend.Domain.DTOs.Filters;
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


    public async Task<ArticlePackagingBreakdown?> GetByIdAsync(int id)
    {
        return await _context.ArticlePackagingBreakdowns.FindAsync(id);
    }

    public async Task<(List<ArticlePackagingBreakdown> Items, int TotalCount)> GetFilteredAsync(
        ArticlePackagingBreakdownFilterDto filter, int pageNumber, int pageSize)
    {
        var query = _context.ArticlePackagingBreakdowns.AsQueryable();

     
        if (filter.Id.HasValue)
            query = query.Where(x => x.Id == filter.Id);

        if (filter.ArticleId.HasValue)
            query = query.Where(x => x.ArticleId == filter.ArticleId);

        if (!string.IsNullOrEmpty(filter.FromUnit))
            query = query.Where(x => x.FromUnit == filter.FromUnit);

        if (filter.FromUnitId.HasValue)
            query = query.Where(x => x.FromUnitId == filter.FromUnitId);

        if (filter.MinFromFactor.HasValue)
            query = query.Where(x => x.FromFactor >= filter.MinFromFactor);
        if (filter.MaxFromFactor.HasValue)
            query = query.Where(x => x.FromFactor <= filter.MaxFromFactor);

        if (!string.IsNullOrEmpty(filter.ToUnit))
            query = query.Where(x => x.ToUnit == filter.ToUnit);

        if (filter.ToUnitId.HasValue)
            query = query.Where(x => x.ToUnitId == filter.ToUnitId);

        if (filter.MinToFactor.HasValue)
            query = query.Where(x => x.ToFactor >= filter.MinToFactor);
        if (filter.MaxToFactor.HasValue)
            query = query.Where(x => x.ToFactor <= filter.MaxToFactor);

        if (filter.MinCubes.HasValue)
            query = query.Where(x => x.Cubes >= filter.MinCubes);
        if (filter.MaxCubes.HasValue)
            query = query.Where(x => x.Cubes <= filter.MaxCubes);

        if (filter.StatusInUse.HasValue)
            query = query.Where(x => x.StatusInUse == filter.StatusInUse);

        if (filter.IsERP.HasValue)
            query = query.Where(x => x.IsERP == filter.IsERP);

        if (filter.IsMinimumPackaging.HasValue)
            query = query.Where(x => x.IsMinimumPackaging == filter.IsMinimumPackaging);

      
        var totalCount = await query.CountAsync();

       
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}