using EcommerceAdminBackend.API.Models;

namespace EcommerceAdminBackend.API.Repositories;

public interface IArticleRepository
{
 
    Task<List<Article>> GetAllArticlesAsync(int pageNumber, int pageSize);
    Task<int> GetTotalArticlesCountAsync();
    
    Task<Article?> GetArticleByIdAsync(int id);
  
    // ✅ Search by Unique Identifiers
        Task<Article?> GetArticleByArticleIdAsync(int articleId);
        Task<List<Article>> GetArticlesByCodeAsync(string code);

        // ✅ Search by Descriptive Fields
        Task<List<Article>> GetArticlesByDescriptionAsync(string description);
        Task<List<Article>> GetArticlesByProductAsync(string product);
        Task<List<Article>> GetArticlesByProductDescriptionAsync(string productDescription);
        Task<List<Article>> GetArticlesByProductGroupAsync(string productGroup);
        Task<List<Article>> GetArticlesByProductSegmentationAsync(string productSegmentation);
        Task<List<Article>> GetArticlesByProductTypeAsync(string productType);
        Task<List<Article>> GetArticlesByCompetenceCenterAsync(string competenceCenter);
        Task<List<Article>> GetArticlesBySectorAsync(string sector);
        Task<List<Article>> GetArticlesByMaterialAsync(string material);
        Task<List<Article>> GetArticlesByBrandAsync(string brand);
        Task<List<Article>> GetArticlesByTypeAsync(string type);
        Task<List<Article>> GetArticlesByFinishAsync(string finish);
        Task<List<Article>> GetArticlesByColorAsync(string color);
        Task<List<Article>> GetArticlesByFireClassAsync(string fireClass);
        Task<List<Article>> GetArticlesByEdgeFinishAsync(string edgeFinish);
        Task<List<Article>> GetArticlesByCoatingAsync(string coating);

        // ✅ Search by Measurement Fields
        Task<List<Article>> GetArticlesByDiameterAsync(decimal diameter);
        Task<List<Article>> GetArticlesByDiameterUnitAsync(string diameterUnit);
        Task<List<Article>> GetArticlesByLengthAsync(decimal length);
        Task<List<Article>> GetArticlesByLengthUnitAsync(string lengthUnit);
        Task<List<Article>> GetArticlesByThicknessAsync(decimal thickness);
        Task<List<Article>> GetArticlesByThicknessUnitAsync(string thicknessUnit);
        Task<List<Article>> GetArticlesByWidthAsync(decimal width);
        Task<List<Article>> GetArticlesByWidthUnitAsync(string widthUnit);
        Task<List<Article>> GetArticlesByVolumeAsync(decimal volume);
        Task<List<Article>> GetArticlesByVolumeUnitAsync(string volumeUnit);
        Task<List<Article>> GetArticlesByWeightAsync(decimal weight);
        Task<List<Article>> GetArticlesByWeightUnitAsync(string weightUnit);

        // ✅ Search by Boolean & Other Fields
        Task<List<Article>> GetPublishedArticlesAsync(bool published);
        Task<List<Article>> GetArticlesByPricingUnitAsync(string pricingUnit);
        Task<List<Article>> GetArticlesByPricingUnitIdAsync(int pricingUnitId);
        Task<List<Article>> GetArticlesByPackagingUnitAsync(string packagingUnit);
        Task<List<Article>> GetArticlesByPackagingUnitIdAsync(int packagingUnitId);
        Task<List<Article>> GetArticlesByProductIdAsync(Guid productId);
        Task<List<Article>> GetArticlesByIndexAsync(int index);
        Task<List<Article>> GetArticlesByRAsync(decimal r);
        Task<List<Article>> GetArticlesByRUnitAsync(string rUnit);
        Task<List<Article>> GetArticlesByApplicationAsync(string application);
        Task<List<Article>> GetArticlesByExtraInfoAsync(string extraInfo);
    
}