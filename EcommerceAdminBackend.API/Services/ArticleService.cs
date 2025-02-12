using EcommerceAdminBackend.API.Models;
using EcommerceAdminBackend.API.Repositories;
using EcommerceAdminBackend.API.Utilities;

namespace EcommerceAdminBackend.API.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }
    
        
    public async Task<PaginatedResponse<Article>> GetAllArticlesAsync(int pageNumber, int pageSize)
    {
        var totalRecords = await _articleRepository.GetTotalArticlesCountAsync();
        var articles = await _articleRepository.GetAllArticlesAsync(pageNumber, pageSize);
        return new PaginatedResponse<Article>(articles, pageNumber, pageSize, totalRecords);
    }

        public async Task<Article?> GetArticleByIdAsync(int id)
        {
            if (id < 0)
            {
                return null;
            }
            return await _articleRepository.GetArticleByIdAsync(id);
        }

        public async Task<Article?> GetArticleByArticleIdAsync(int articleId)
        {
            if (articleId <= 0) return null; 
            return await _articleRepository.GetArticleByArticleIdAsync(articleId);
        }

        public async Task<List<Article>> GetArticlesByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return new List<Article>(); 
            return await _articleRepository.GetArticlesByCodeAsync(code);
        }

        public async Task<List<Article>> GetArticlesByDescriptionAsync(string description)
        {
            if (string.IsNullOrWhiteSpace(description)) return new List<Article>();
            return await _articleRepository.GetArticlesByDescriptionAsync(description);
        }

        public async Task<List<Article>> GetArticlesByProductAsync(string product)
        {
            if (string.IsNullOrWhiteSpace(product)) return new List<Article>();
            return await _articleRepository.GetArticlesByProductAsync(product);
        }

        public async Task<List<Article>> GetArticlesByProductDescriptionAsync(string productDescription)
        {
            if (string.IsNullOrWhiteSpace(productDescription)) return new List<Article>();
            return await _articleRepository.GetArticlesByProductDescriptionAsync(productDescription);
        }

        public async Task<List<Article>> GetArticlesByProductGroupAsync(string productGroup)
        {
            if (string.IsNullOrWhiteSpace(productGroup)) return new List<Article>();
            return await _articleRepository.GetArticlesByProductGroupAsync(productGroup);
        }

        public async Task<List<Article>> GetArticlesByProductSegmentationAsync(string productSegmentation)
        {
            if (string.IsNullOrWhiteSpace(productSegmentation)) return new List<Article>();
            return await _articleRepository.GetArticlesByProductSegmentationAsync(productSegmentation);
        }

        public async Task<List<Article>> GetArticlesByProductTypeAsync(string productType)
        {
            if (string.IsNullOrWhiteSpace(productType)) return new List<Article>();
            return await _articleRepository.GetArticlesByProductTypeAsync(productType);
        }

        public async Task<List<Article>> GetArticlesByCompetenceCenterAsync(string competenceCenter)
        {
            if (string.IsNullOrWhiteSpace(competenceCenter)) return new List<Article>();
            return await _articleRepository.GetArticlesByCompetenceCenterAsync(competenceCenter);
        }

        public async Task<List<Article>> GetArticlesBySectorAsync(string sector)
        {
            if (string.IsNullOrWhiteSpace(sector)) return new List<Article>();
            return await _articleRepository.GetArticlesBySectorAsync(sector);
        }

        public async Task<List<Article>> GetArticlesByMaterialAsync(string material)
        {
            if (string.IsNullOrWhiteSpace(material)) return new List<Article>();
            return await _articleRepository.GetArticlesByMaterialAsync(material);
        }

        public async Task<List<Article>> GetArticlesByBrandAsync(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand)) return new List<Article>();
            return await _articleRepository.GetArticlesByBrandAsync(brand);
        }

        public async Task<List<Article>> GetArticlesByTypeAsync(string type)
        {
            if (string.IsNullOrWhiteSpace(type)) return new List<Article>();
            return await _articleRepository.GetArticlesByTypeAsync(type);
        }

        public async Task<List<Article>> GetArticlesByFinishAsync(string finish)
        {
            if (string.IsNullOrWhiteSpace(finish)) return new List<Article>();
            return await _articleRepository.GetArticlesByFinishAsync(finish);
        }

        public async Task<List<Article>> GetArticlesByColorAsync(string color)
        {
            if (string.IsNullOrWhiteSpace(color)) return new List<Article>();
            return await _articleRepository.GetArticlesByColorAsync(color);
        }

        public async Task<List<Article>> GetArticlesByFireClassAsync(string fireClass)
        {
            if (string.IsNullOrWhiteSpace(fireClass)) return new List<Article>();
            return await _articleRepository.GetArticlesByFireClassAsync(fireClass);
        }

        public async Task<List<Article>> GetArticlesByEdgeFinishAsync(string edgeFinish)
        {
            if (string.IsNullOrWhiteSpace(edgeFinish)) return new List<Article>();
            return await _articleRepository.GetArticlesByEdgeFinishAsync(edgeFinish);
        }

        public async Task<List<Article>> GetArticlesByCoatingAsync(string coating)
        {
            if (string.IsNullOrWhiteSpace(coating)) return new List<Article>();
            return await _articleRepository.GetArticlesByCoatingAsync(coating);
        }

        public async Task<List<Article>> GetArticlesByDiameterAsync(decimal diameter)
        {
            if (diameter <= 0)
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByDiameterAsync(diameter);
        }

        public async Task<List<Article>> GetArticlesByDiameterUnitAsync(string diameterUnit)
        {
            if (string.IsNullOrWhiteSpace(diameterUnit))
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByDiameterUnitAsync(diameterUnit);
        }

        public async Task<List<Article>> GetArticlesByLengthAsync(decimal length)
        {
            if (length <= 0)
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByLengthAsync(length);
        }

        public async Task<List<Article>> GetArticlesByLengthUnitAsync(string lengthUnit)
        {
            if (string.IsNullOrWhiteSpace(lengthUnit))
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByLengthUnitAsync(lengthUnit);
        }

        public async Task<List<Article>> GetArticlesByThicknessAsync(decimal thickness)
        {
            if (thickness <= 0)
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByThicknessAsync(thickness);
        }

        public async Task<List<Article>> GetArticlesByThicknessUnitAsync(string thicknessUnit)
        {
            if (string.IsNullOrWhiteSpace(thicknessUnit))
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByThicknessUnitAsync(thicknessUnit);
        }

        public async Task<List<Article>> GetArticlesByWidthAsync(decimal width)
        {
            if (width <= 0)
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByWidthAsync(width);
        }

        public async Task<List<Article>> GetArticlesByWidthUnitAsync(string widthUnit)
        {
            if (string.IsNullOrWhiteSpace(widthUnit))
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByWidthUnitAsync(widthUnit);
        }

        public async Task<List<Article>> GetArticlesByVolumeAsync(decimal volume)
        {
            if (volume <= 0)
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByVolumeAsync(volume);
        }

        public async Task<List<Article>> GetArticlesByVolumeUnitAsync(string volumeUnit)
        {
            if (string.IsNullOrWhiteSpace(volumeUnit))
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByVolumeUnitAsync(volumeUnit);
        }

        public async Task<List<Article>> GetArticlesByWeightAsync(decimal weight)
        {
            if (weight <= 0)
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByWeightAsync(weight);
        }

        public async Task<List<Article>> GetArticlesByWeightUnitAsync(string weightUnit)
        {
            if (string.IsNullOrWhiteSpace(weightUnit))
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByWeightUnitAsync(weightUnit);
        }

        public async Task<List<Article>> GetPublishedArticlesAsync(bool published)
        {
            
            return await _articleRepository.GetPublishedArticlesAsync(published);
        }

        public async Task<List<Article>> GetArticlesByPricingUnitAsync(string pricingUnit)
        {
            if (string.IsNullOrWhiteSpace(pricingUnit))
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByPricingUnitAsync(pricingUnit);
        }

        public async Task<List<Article>> GetArticlesByPricingUnitIdAsync(int pricingUnitId)
        {
            if (pricingUnitId <= 0)
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByPricingUnitIdAsync(pricingUnitId);
        }

        public async Task<List<Article>> GetArticlesByPackagingUnitAsync(string packagingUnit)
        {
            if (string.IsNullOrWhiteSpace(packagingUnit))
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByPackagingUnitAsync(packagingUnit);
        }

        public async Task<List<Article>> GetArticlesByPackagingUnitIdAsync(int packagingUnitId)
        {
            if (packagingUnitId <= 0)
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByPackagingUnitIdAsync(packagingUnitId);
        }

        public async Task<List<Article>> GetArticlesByProductIdAsync(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByProductIdAsync(productId);
        }

        public async Task<List<Article>> GetArticlesByIndexAsync(int index)
        {
            if (index <= 0)
            {
                return new List<Article>();
            }
            return await _articleRepository.GetArticlesByIndexAsync(index);
        }
}