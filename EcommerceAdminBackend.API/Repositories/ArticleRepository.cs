using EcommerceAdminBackend.API.Data;
using EcommerceAdminBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAdminBackend.API.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly ApplicationDbContext _context;
    
    public ArticleRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Article>> GetAllArticlesAsync(int pageNumber, int pageSize)
    {
        return await _context.Articles
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalArticlesCountAsync()
    {
        return await _context.Articles.CountAsync();
    }

        public async Task<Article?> GetArticleByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<Article?> GetArticleByArticleIdAsync(int articleId)
        {
            return await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == articleId);
        }

        public async Task<List<Article>> GetArticlesByCodeAsync(string code)
        {
            return await _context.Articles.Where(a => a.Code == code).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByDescriptionAsync(string description)
        {
            return await _context.Articles.Where(a => a.Description.Contains(description)).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByProductAsync(string product)
        {
            return await _context.Articles.Where(a => a.Product == product).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByProductDescriptionAsync(string productDescription)
        {
            return await _context.Articles.Where(a => a.ProductDescription.Contains(productDescription)).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByProductGroupAsync(string productGroup)
        {
            return await _context.Articles.Where(a => a.ProductGroup == productGroup).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByProductSegmentationAsync(string productSegmentation)
        {
            return await _context.Articles.Where(a => a.ProductSegmentation == productSegmentation).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByProductTypeAsync(string productType)
        {
            return await _context.Articles.Where(a => a.ProductType == productType).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByCompetenceCenterAsync(string competenceCenter)
        {
            return await _context.Articles.Where(a => a.CompetenceCenter == competenceCenter).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesBySectorAsync(string sector)
        {
            return await _context.Articles.Where(a => a.Sector == sector).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByMaterialAsync(string material)
        {
            return await _context.Articles.Where(a => a.Material == material).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByBrandAsync(string brand)
        {
            return await _context.Articles.Where(a => a.Brand == brand).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByTypeAsync(string type)
        {
            return await _context.Articles.Where(a => a.Type == type).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByFinishAsync(string finish)
        {
            return await _context.Articles.Where(a => a.Finish == finish).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByColorAsync(string color)
        {
            return await _context.Articles.Where(a => a.Color == color).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByFireClassAsync(string fireClass)
        {
            return await _context.Articles.Where(a => a.FireClass == fireClass).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByEdgeFinishAsync(string edgeFinish)
        {
            return await _context.Articles.Where(a => a.EdgeFinish == edgeFinish).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByCoatingAsync(string coating)
        {
            return await _context.Articles.Where(a => a.Coating == coating).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByDiameterAsync(decimal diameter)
        {
            return await _context.Articles.Where(a => a.Diameter == diameter).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByDiameterUnitAsync(string diameterUnit)
        {
            return await _context.Articles.Where(a => a.DiameterUnit == diameterUnit).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByLengthAsync(decimal length)
        {
            return await _context.Articles.Where(a => a.Length == length).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByLengthUnitAsync(string lengthUnit)
        {
            return await _context.Articles.Where(a => a.LengthUnit == lengthUnit).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByThicknessAsync(decimal thickness)
        {
            return await _context.Articles.Where(a => a.Thickness == thickness).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByThicknessUnitAsync(string thicknessUnit)
        {
            return await _context.Articles.Where(a => a.ThicknessUnit == thicknessUnit).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByWidthAsync(decimal width)
        {
            return await _context.Articles.Where(a => a.Width == width).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByWidthUnitAsync(string widthUnit)
        {
            return await _context.Articles.Where(a => a.WidthUnit == widthUnit).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByVolumeAsync(decimal volume)
        {
            return await _context.Articles.Where(a => a.Volume == volume).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByVolumeUnitAsync(string volumeUnit)
        {
            return await _context.Articles.Where(a => a.VolumeUnit == volumeUnit).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByWeightAsync(decimal weight)
        {
            return await _context.Articles.Where(a => a.Weight == weight).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByWeightUnitAsync(string weightUnit)
        {
            return await _context.Articles.Where(a => a.WeightUnit == weightUnit).ToListAsync();
        }

        public async Task<List<Article>> GetPublishedArticlesAsync(bool published)
        {
            return await _context.Articles.Where(a => a.Published == published).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByPricingUnitAsync(string pricingUnit)
        {
            return await _context.Articles.Where(a => a.PricingUnit == pricingUnit).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByPricingUnitIdAsync(int pricingUnitId)
        {
            return await _context.Articles.Where(a => a.PricingUnitId == pricingUnitId).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByPackagingUnitAsync(string packagingUnit)
        {
            return await _context.Articles.Where(a => a.PackagingUnit == packagingUnit).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByPackagingUnitIdAsync(int packagingUnitId)
        {
            return await _context.Articles.Where(a => a.PackagingUnitId == packagingUnitId).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByProductIdAsync(Guid productId)
        {
            return await _context.Articles.Where(a => a.ProductId == productId).ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByIndexAsync(int index)
        {
            return await _context.Articles.Where(a => a.Index == index).ToListAsync();
        }
}