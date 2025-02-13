
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceAdminBackend.API.Data;
using EcommerceAdminBackend.API.Models;
using EcommerceAdminBackend.API.Services;
using EcommerceAdminBackend.API.Utilities;

namespace EcommerceAdminBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlePackagingBreakdownController : ControllerBase
    {
        private readonly IArticlePackagingBreakdownService _articlePackagingBreakdownService;

        public ArticlePackagingBreakdownController(IArticlePackagingBreakdownService articlePackagingBreakdownService)
        {
            _articlePackagingBreakdownService = articlePackagingBreakdownService;
        }
        

       [HttpGet]
        public async Task<ActionResult<PaginatedResponse<ArticlePackagingBreakdown>>> GetArticlePackagingBreakdown(int pageNumber = 1, int pageSize = 10){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetAllArticlePackagingBreakdownAsync(pageNumber, pageSize);
            return Ok(articlePackagingBreakdown);
        }
        
        // give me the rest of the endpoints
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticlePackagingBreakdown>> GetArticlePackagingBreakdownById(int id){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetArticlePackagingBreakdownByIdAsync(id);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("articleid/{articleId}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByArticleId(int articleId){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByArticleIdAsync(articleId);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("fromunit/{fromUnit}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByFromUnit(string fromUnit){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByFromUnitAsync(fromUnit);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("tounit/{toUnit}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByToUnit(string toUnit){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByToUnitAsync(toUnit);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("fromunitid/{fromUnitId}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByFromUnitId(int fromUnitId){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByFromUnitIdAsync(fromUnitId);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("tounitid/{toUnitId}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByToUnitId(int toUnitId){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByToUnitIdAsync(toUnitId);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("fromfactor/{fromFactor}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByFromFactor(decimal fromFactor){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByFromFactorAsync(fromFactor);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("tofactor/{toFactor}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByToFactor(decimal toFactor){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByToFactorAsync(toFactor);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("cubes/{cubes}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByCubes(decimal cubes){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByCubesAsync(cubes);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("statusinuse/{statusInUse}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByStatusInUse(bool statusInUse){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByStatusInUseAsync(statusInUse);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("iserp/{isERP}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByIsERP(bool isERP){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByIsERPAsync(isERP);
            return Ok(articlePackagingBreakdown);
        }
        
        [HttpGet("isminimumpackaging/{isMinimumPackaging}")]
        public async Task<ActionResult<List<ArticlePackagingBreakdown>>> GetBreakdownsByIsMinimumPackaging(bool isMinimumPackaging){
            var articlePackagingBreakdown = await _articlePackagingBreakdownService.GetBreakdownsByIsMinimumPackagingAsync(isMinimumPackaging);
            return Ok(articlePackagingBreakdown);
        }
        

       
    }
}
