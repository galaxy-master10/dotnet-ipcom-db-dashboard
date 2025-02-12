using EcommerceAdminBackend.API.Models;
using EcommerceAdminBackend.API.Repositories;

namespace EcommerceAdminBackend.API.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }
    
        public async Task<List<Article>> GetAllArticlesAsync()
        {
            return await _articleRepository.GetAllArticlesAsync();
        }

        public async Task<Article?> GetArticleByIdAsync(int id)
        {
            return await _articleRepository.GetArticleByIdAsync(id);
        }

        public async Task<Article?> GetArticleByArticleIdAsync(int articleId)
        {
            return await _articleRepository.GetArticleByArticleIdAsync(articleId);
        }

        public async Task<List<Article>> GetArticlesByCodeAsync(string code)
        {
            return await _articleRepository.GetArticlesByCodeAsync(code);
        }

        public async Task<List<Article>> GetArticlesByDescriptionAsync(string description)
        {
            return await _articleRepository.GetArticlesByDescriptionAsync(description);
        }

        public async Task<List<Article>> GetArticlesByProductAsync(string product)
        {
            return await _articleRepository.GetArticlesByProductAsync(product);
        }

        public async Task<List<Article>> GetArticlesByProductDescriptionAsync(string productDescription)
        {
            return await _articleRepository.GetArticlesByProductDescriptionAsync(productDescription);
        }

        public async Task<List<Article>> GetArticlesByProductGroupAsync(string productGroup)
        {
            return await _articleRepository.GetArticlesByProductGroupAsync(productGroup);
        }

        public async Task<List<Article>> GetArticlesByProductSegmentationAsync(string productSegmentation)
        {
            return await _articleRepository.GetArticlesByProductSegmentationAsync(productSegmentation);
        }

        public async Task<List<Article>> GetArticlesByProductTypeAsync(string productType)
        {
            return await _articleRepository.GetArticlesByProductTypeAsync(productType);
        }

        public async Task<List<Article>> GetArticlesByCompetenceCenterAsync(string competenceCenter)
        {
            return await _articleRepository.GetArticlesByCompetenceCenterAsync(competenceCenter);
        }

        public async Task<List<Article>> GetArticlesBySectorAsync(string sector)
        {
            return await _articleRepository.GetArticlesBySectorAsync(sector);
        }

        public async Task<List<Article>> GetArticlesByMaterialAsync(string material)
        {
            return await _articleRepository.GetArticlesByMaterialAsync(material);
        }

        public async Task<List<Article>> GetArticlesByBrandAsync(string brand)
        {
            return await _articleRepository.GetArticlesByBrandAsync(brand);
        }

        public async Task<List<Article>> GetArticlesByTypeAsync(string type)
        {
            return await _articleRepository.GetArticlesByTypeAsync(type);
        }

        public async Task<List<Article>> GetArticlesByFinishAsync(string finish)
        {
            return await _articleRepository.GetArticlesByFinishAsync(finish);
        }

        public async Task<List<Article>> GetArticlesByColorAsync(string color)
        {
            return await _articleRepository.GetArticlesByColorAsync(color);
        }

        public async Task<List<Article>> GetArticlesByFireClassAsync(string fireClass)
        {
            return await _articleRepository.GetArticlesByFireClassAsync(fireClass);
        }

        public async Task<List<Article>> GetArticlesByEdgeFinishAsync(string edgeFinish)
        {
            return await _articleRepository.GetArticlesByEdgeFinishAsync(edgeFinish);
        }

        public async Task<List<Article>> GetArticlesByCoatingAsync(string coating)
        {
            return await _articleRepository.GetArticlesByCoatingAsync(coating);
        }

        public async Task<List<Article>> GetArticlesByDiameterAsync(decimal diameter)
        {
            return await _articleRepository.GetArticlesByDiameterAsync(diameter);
        }

        public async Task<List<Article>> GetArticlesByDiameterUnitAsync(string diameterUnit)
        {
            return await _articleRepository.GetArticlesByDiameterUnitAsync(diameterUnit);
        }

        public async Task<List<Article>> GetArticlesByLengthAsync(decimal length)
        {
            return await _articleRepository.GetArticlesByLengthAsync(length);
        }

        public async Task<List<Article>> GetArticlesByLengthUnitAsync(string lengthUnit)
        {
            return await _articleRepository.GetArticlesByLengthUnitAsync(lengthUnit);
        }

        public async Task<List<Article>> GetArticlesByThicknessAsync(decimal thickness)
        {
            return await _articleRepository.GetArticlesByThicknessAsync(thickness);
        }

        public async Task<List<Article>> GetArticlesByThicknessUnitAsync(string thicknessUnit)
        {
            return await _articleRepository.GetArticlesByThicknessUnitAsync(thicknessUnit);
        }

        public async Task<List<Article>> GetArticlesByWidthAsync(decimal width)
        {
            return await _articleRepository.GetArticlesByWidthAsync(width);
        }

        public async Task<List<Article>> GetArticlesByWidthUnitAsync(string widthUnit)
        {
            return await _articleRepository.GetArticlesByWidthUnitAsync(widthUnit);
        }

        public async Task<List<Article>> GetArticlesByVolumeAsync(decimal volume)
        {
            return await _articleRepository.GetArticlesByVolumeAsync(volume);
        }

        public async Task<List<Article>> GetArticlesByVolumeUnitAsync(string volumeUnit)
        {
            return await _articleRepository.GetArticlesByVolumeUnitAsync(volumeUnit);
        }

        public async Task<List<Article>> GetArticlesByWeightAsync(decimal weight)
        {
            return await _articleRepository.GetArticlesByWeightAsync(weight);
        }

        public async Task<List<Article>> GetArticlesByWeightUnitAsync(string weightUnit)
        {
            return await _articleRepository.GetArticlesByWeightUnitAsync(weightUnit);
        }

        public async Task<List<Article>> GetPublishedArticlesAsync(bool published)
        {
            return await _articleRepository.GetPublishedArticlesAsync(published);
        }

        public async Task<List<Article>> GetArticlesByPricingUnitAsync(string pricingUnit)
        {
            return await _articleRepository.GetArticlesByPricingUnitAsync(pricingUnit);
        }

        public async Task<List<Article>> GetArticlesByPricingUnitIdAsync(int pricingUnitId)
        {
            return await _articleRepository.GetArticlesByPricingUnitIdAsync(pricingUnitId);
        }

        public async Task<List<Article>> GetArticlesByPackagingUnitAsync(string packagingUnit)
        {
            return await _articleRepository.GetArticlesByPackagingUnitAsync(packagingUnit);
        }

        public async Task<List<Article>> GetArticlesByPackagingUnitIdAsync(int packagingUnitId)
        {
            return await _articleRepository.GetArticlesByPackagingUnitIdAsync(packagingUnitId);
        }

        public async Task<List<Article>> GetArticlesByProductIdAsync(Guid productId)
        {
            return await _articleRepository.GetArticlesByProductIdAsync(productId);
        }

        public async Task<List<Article>> GetArticlesByIndexAsync(int index)
        {
            return await _articleRepository.GetArticlesByIndexAsync(index);
        }
}