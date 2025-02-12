using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceAdminBackend.API.Data;
using EcommerceAdminBackend.API.Models;
using EcommerceAdminBackend.API.Services;

namespace EcommerceAdminBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        
         [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            var articles = await _articleService.GetAllArticlesAsync();
            if (articles.Count == 0) return NotFound("No articles found.");
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);
            if (article == null)
            {
                return NotFound($"Article with ID {id} not found.");
            }
            return Ok(article);
        }

        [HttpGet("articleid/{articleId}")]
        public async Task<ActionResult<Article>> GetArticleByArticleId(int articleId)
        {
            var article = await _articleService.GetArticleByArticleIdAsync(articleId);
            if (article == null)
            {
                return NotFound($"Article with Article ID {articleId} not found.");
            }
            return Ok(article);
        }

        [HttpGet("articlecode/{articleCode}")]
        public async Task<ActionResult<Article>> GetArticleByArticleCode(string articleCode)
        {
            var article = await _articleService.GetArticlesByCodeAsync(articleCode);
            if (article == null)
            {
                return NotFound($"Article with Article Code {articleCode} not found.");
            }
            return Ok(article);
        }

        [HttpGet("productsegmentation/{productSegmentation}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByProductSegmentation(string productSegmentation)
        {
            var articles = await _articleService.GetArticlesByProductSegmentationAsync(productSegmentation);
            if (articles.Count == 0) return NotFound("No articles found for the given product segmentation.");
            return Ok(articles);
        }

        [HttpGet("producttype/{productType}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByProductType(string productType)
        {
            var articles = await _articleService.GetArticlesByProductTypeAsync(productType);
            if (articles.Count == 0) return NotFound("No articles found for the given product type.");
            return Ok(articles);
        }

        [HttpGet("competencecenter/{competenceCenter}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByCompetenceCenter(string competenceCenter)
        {
            var articles = await _articleService.GetArticlesByCompetenceCenterAsync(competenceCenter);
            if (articles.Count == 0) return NotFound("No articles found for the given competence center.");
            return Ok(articles);
        }

        [HttpGet("sector/{sector}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesBySector(string sector)
        {
            var articles = await _articleService.GetArticlesBySectorAsync(sector);
            if (articles.Count == 0) return NotFound("No articles found for the given sector.");
            return Ok(articles);
        }

        [HttpGet("material/{material}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByMaterial(string material)
        {
            var articles = await _articleService.GetArticlesByMaterialAsync(material);
            if (articles.Count == 0) return NotFound("No articles found for the given material.");
            return Ok(articles);
        }

        [HttpGet("brand/{brand}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByBrand(string brand)
        {
            var articles = await _articleService.GetArticlesByBrandAsync(brand);
            if (articles.Count == 0) return NotFound("No articles found for the given brand.");
            return Ok(articles);
        }

        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByType(string type)
        {
            var articles = await _articleService.GetArticlesByTypeAsync(type);
            if (articles.Count == 0) return NotFound("No articles found for the given type.");
            return Ok(articles);
        }

        [HttpGet("finish/{finish}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByFinish(string finish)
        {
            var articles = await _articleService.GetArticlesByFinishAsync(finish);
            if (articles.Count == 0) return NotFound("No articles found for the given finish.");
            return Ok(articles);
        }

        [HttpGet("color/{color}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByColor(string color)
        {
            var articles = await _articleService.GetArticlesByColorAsync(color);
            if (articles.Count == 0) return NotFound("No articles found for the given color.");
            return Ok(articles);
        }

        [HttpGet("fireclass/{fireClass}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByFireClass(string fireClass)
        {
            var articles = await _articleService.GetArticlesByFireClassAsync(fireClass);
            if (articles.Count == 0) return NotFound("No articles found for the given fire class.");
            return Ok(articles);
        }

        [HttpGet("edgefinish/{edgeFinish}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByEdgeFinish(string edgeFinish)
        {
            var articles = await _articleService.GetArticlesByEdgeFinishAsync(edgeFinish);
            if (articles.Count == 0) return NotFound("No articles found for the given edge finish.");
            return Ok(articles);
        }

        [HttpGet("coating/{coating}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByCoating(string coating)
        {
            var articles = await _articleService.GetArticlesByCoatingAsync(coating);
            if (articles.Count == 0) return NotFound("No articles found for the given coating.");
            return Ok(articles);
        }

        [HttpGet("diameter/{diameter}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByDiameter(decimal diameter)
        {
            var articles = await _articleService.GetArticlesByDiameterAsync(diameter);
            if (articles.Count == 0) return NotFound("No articles found for the given diameter.");
            return Ok(articles);
        }

        [HttpGet("diameterunit/{diameterUnit}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByDiameterUnit(string diameterUnit)
        {
            var articles = await _articleService.GetArticlesByDiameterUnitAsync(diameterUnit);
            if (articles.Count == 0) return NotFound("No articles found for the given diameter unit.");
            return Ok(articles);
        }

        [HttpGet("length/{length}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByLength(decimal length)
        {
            var articles = await _articleService.GetArticlesByLengthAsync(length);
            if (articles.Count == 0) return NotFound("No articles found for the given length.");
            return Ok(articles);
        }

        [HttpGet("lengthunit/{lengthUnit}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByLengthUnit(string lengthUnit)
        {
            var articles = await _articleService.GetArticlesByLengthUnitAsync(lengthUnit);
            if (articles.Count == 0) return NotFound("No articles found for the given length unit.");
            return Ok(articles);
        }

        [HttpGet("thickness/{thickness}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByThickness(decimal thickness)
        {
            var articles = await _articleService.GetArticlesByThicknessAsync(thickness);
            if (articles.Count == 0) return NotFound("No articles found for the given thickness.");
            return Ok(articles);
        }

        [HttpGet("thicknessunit/{thicknessUnit}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByThicknessUnit(string thicknessUnit)
        {
            var articles = await _articleService.GetArticlesByThicknessUnitAsync(thicknessUnit);
            if (articles.Count == 0) return NotFound("No articles found for the given thickness unit.");
            return Ok(articles);
        }

        [HttpGet("width/{width}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByWidth(decimal width)
        {
            var articles = await _articleService.GetArticlesByWidthAsync(width);
            if (articles.Count == 0) return NotFound("No articles found for the given width.");
            return Ok(articles);
        }

        [HttpGet("widthunit/{widthUnit}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByWidthUnit(string widthUnit)
        {
            var articles = await _articleService.GetArticlesByWidthUnitAsync(widthUnit);
            if (articles.Count == 0) return NotFound("No articles found for the given width unit.");
            return Ok(articles);
        }

        [HttpGet("volume/{volume}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByVolume(decimal volume)
        {
            var articles = await _articleService.GetArticlesByVolumeAsync(volume);
            if (articles.Count == 0) return NotFound("No articles found for the given volume.");
            return Ok(articles);
        }

        [HttpGet("volumeunit/{volumeUnit}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByVolumeUnit(string volumeUnit)
        {
            var articles = await _articleService.GetArticlesByVolumeUnitAsync(volumeUnit);
            if (articles.Count == 0) return NotFound("No articles found for the given volume unit.");
            return Ok(articles);
        }

        [HttpGet("weight/{weight}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByWeight(decimal weight)
        {
            var articles = await _articleService.GetArticlesByWeightAsync(weight);
            if (articles.Count == 0) return NotFound("No articles found for the given weight.");
            return Ok(articles);
        }

        [HttpGet("weightunit/{weightUnit}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByWeightUnit(string weightUnit)
        {
            var articles = await _articleService.GetArticlesByWeightUnitAsync(weightUnit);
            if (articles.Count == 0) return NotFound("No articles found for the given weight unit.");
            return Ok(articles);
        }

        [HttpGet("published/{published}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetPublishedArticles(bool published)
        {
            var articles = await _articleService.GetPublishedArticlesAsync(published);
            if (articles.Count == 0) return NotFound("No articles found for the given published status.");
            return Ok(articles);
        }

        [HttpGet("pricingunit/{pricingUnit}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByPricingUnit(string pricingUnit)
        {
            var articles = await _articleService.GetArticlesByPricingUnitAsync(pricingUnit);
            if (articles.Count == 0) return NotFound("No articles found for the given pricing unit.");
            return Ok(articles);
        }

        [HttpGet("pricingunitid/{pricingUnitId}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByPricingUnitId(int pricingUnitId)
        {
            var articles = await _articleService.GetArticlesByPricingUnitIdAsync(pricingUnitId);
            if (articles.Count == 0) return NotFound("No articles found for the given pricing unit ID.");
            return Ok(articles);
        }

        [HttpGet("packagingunit/{packagingUnit}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByPackagingUnit(string packagingUnit)
        {
            var articles = await _articleService.GetArticlesByPackagingUnitAsync(packagingUnit);
            if (articles.Count == 0) return NotFound("No articles found for the given packaging unit.");
            return Ok(articles);
        }

        [HttpGet("packagingunitid/{packagingUnitId}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByPackagingUnitId(int packagingUnitId)
        {
            var articles = await _articleService.GetArticlesByPackagingUnitIdAsync(packagingUnitId);
            if (articles.Count == 0) return NotFound("No articles found for the given packaging unit ID.");
            return Ok(articles);
        }

        [HttpGet("productid/{productId}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByProductId(Guid productId)
        {
            var articles = await _articleService.GetArticlesByProductIdAsync(productId);
            if (articles.Count == 0) return NotFound("No articles found for the given product ID.");
            return Ok(articles);
        }

        [HttpGet("index/{index}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByIndex(int index)
        {
            var articles = await _articleService.GetArticlesByIndexAsync(index);
            if (articles.Count == 0) return NotFound("No articles found for the given index.");
            return Ok(articles);
        }
        
        
    }
}
