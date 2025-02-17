using EcommerceAdminBackend.Domain.DTOs.Filters;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAdminBackend.Infrastructure.Persistence.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly ApplicationDbContext _context;
    
    public ArticleRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
      public async Task<Article?> GetByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<(List<Article> Items, int TotalCount)> GetFilteredAsync(
            ArticleFilterDto filter, int pageNumber, int pageSize)
        {
            var query = _context.Articles.AsQueryable();

         
            if (filter.Id.HasValue)
                query = query.Where(x => x.Id == filter.Id);

            if (filter.ArticleId.HasValue)
                query = query.Where(x => x.ArticleId == filter.ArticleId);

            if (!string.IsNullOrEmpty(filter.Code))
                query = query.Where(x => x.Code == filter.Code);

            if (!string.IsNullOrEmpty(filter.Description))
                query = query.Where(x => x.Description.Contains(filter.Description));

            if (!string.IsNullOrEmpty(filter.Product))
                query = query.Where(x => x.Product == filter.Product);

            if (!string.IsNullOrEmpty(filter.ProductDescription))
                query = query.Where(x => x.ProductDescription.Contains(filter.ProductDescription));

            if (!string.IsNullOrEmpty(filter.ProductGroup))
                query = query.Where(x => x.ProductGroup == filter.ProductGroup);

            if (!string.IsNullOrEmpty(filter.ProductSegmentation))
                query = query.Where(x => x.ProductSegmentation == filter.ProductSegmentation);

            if (!string.IsNullOrEmpty(filter.ProductType))
                query = query.Where(x => x.ProductType == filter.ProductType);

            if (!string.IsNullOrEmpty(filter.CompetenceCenter))
                query = query.Where(x => x.CompetenceCenter == filter.CompetenceCenter);

            if (!string.IsNullOrEmpty(filter.Sector))
                query = query.Where(x => x.Sector == filter.Sector);

            if (!string.IsNullOrEmpty(filter.Material))
                query = query.Where(x => x.Material == filter.Material);

            // Range filters for measurements
            if (filter.MinDiameter.HasValue)
                query = query.Where(x => x.Diameter >= filter.MinDiameter);
            if (filter.MaxDiameter.HasValue)
                query = query.Where(x => x.Diameter <= filter.MaxDiameter);

            if (filter.MinLength.HasValue)
                query = query.Where(x => x.Length >= filter.MinLength);
            if (filter.MaxLength.HasValue)
                query = query.Where(x => x.Length <= filter.MaxLength);

            if (filter.MinThickness.HasValue)
                query = query.Where(x => x.Thickness >= filter.MinThickness);
            if (filter.MaxThickness.HasValue)
                query = query.Where(x => x.Thickness <= filter.MaxThickness);

            if (filter.MinWidth.HasValue)
                query = query.Where(x => x.Width >= filter.MinWidth);
            if (filter.MaxWidth.HasValue)
                query = query.Where(x => x.Width <= filter.MaxWidth);

            if (filter.MinVolume.HasValue)
                query = query.Where(x => x.Volume >= filter.MinVolume);
            if (filter.MaxVolume.HasValue)
                query = query.Where(x => x.Volume <= filter.MaxVolume);

            if (filter.MinWeight.HasValue)
                query = query.Where(x => x.Weight >= filter.MinWeight);
            if (filter.MaxWeight.HasValue)
                query = query.Where(x => x.Weight <= filter.MaxWeight);

            if (filter.MinR.HasValue)
                query = query.Where(x => x.R >= filter.MinR);
            if (filter.MaxR.HasValue)
                query = query.Where(x => x.R <= filter.MaxR);

            // Unit filters
            if (!string.IsNullOrEmpty(filter.DiameterUnit))
                query = query.Where(x => x.DiameterUnit == filter.DiameterUnit);

            if (!string.IsNullOrEmpty(filter.LengthUnit))
                query = query.Where(x => x.LengthUnit == filter.LengthUnit);

            if (!string.IsNullOrEmpty(filter.ThicknessUnit))
                query = query.Where(x => x.ThicknessUnit == filter.ThicknessUnit);

            if (!string.IsNullOrEmpty(filter.WidthUnit))
                query = query.Where(x => x.WidthUnit == filter.WidthUnit);

            if (!string.IsNullOrEmpty(filter.VolumeUnit))
                query = query.Where(x => x.VolumeUnit == filter.VolumeUnit);

            if (!string.IsNullOrEmpty(filter.WeightUnit))
                query = query.Where(x => x.WeightUnit == filter.WeightUnit);

            if (!string.IsNullOrEmpty(filter.RUnit))
                query = query.Where(x => x.RUnit == filter.RUnit);

            // Other filters
            if (filter.Published.HasValue)
                query = query.Where(x => x.Published == filter.Published);

            if (!string.IsNullOrEmpty(filter.Brand))
                query = query.Where(x => x.Brand == filter.Brand);

            if (!string.IsNullOrEmpty(filter.Type))
                query = query.Where(x => x.Type == filter.Type);

            if (!string.IsNullOrEmpty(filter.Finish))
                query = query.Where(x => x.Finish == filter.Finish);

            if (!string.IsNullOrEmpty(filter.Color))
                query = query.Where(x => x.Color == filter.Color);

            if (!string.IsNullOrEmpty(filter.FireClass))
                query = query.Where(x => x.FireClass == filter.FireClass);

            if (!string.IsNullOrEmpty(filter.EdgeFinish))
                query = query.Where(x => x.EdgeFinish == filter.EdgeFinish);

            if (!string.IsNullOrEmpty(filter.Coating))
                query = query.Where(x => x.Coating == filter.Coating);

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