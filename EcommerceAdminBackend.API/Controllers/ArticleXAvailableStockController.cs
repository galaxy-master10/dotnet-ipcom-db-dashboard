using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAdminBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArticleXAvailableStockController : ControllerBase
    {
        private readonly IArticleXAvailableStockService _articleXAvailableStockService;
        
        public ArticleXAvailableStockController(IArticleXAvailableStockService articleXAvailableStockService)
        {
            _articleXAvailableStockService = articleXAvailableStockService;
        }
        
        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<ArticleXAvailableStock>>> GetArticleXAvailableStocks(int page = 1, int pageSize = 10)
        {
            var paginatedResponse = await _articleXAvailableStockService.GetAllAvailableStockAsync(page, pageSize);
            return Ok(paginatedResponse);
        }
        
        [HttpGet("{articleId}/{companyStockLocationId}")]
        public async Task<ActionResult<ArticleXAvailableStock>> GetArticleXAvailableStock(int articleId, int companyStockLocationId)
        {
            var articleXAvailableStock = await _articleXAvailableStockService.GetAvailableStockByIdAsync(articleId, companyStockLocationId);
            if (articleXAvailableStock == null)
            {
                return NotFound();
            }
            return Ok(articleXAvailableStock);
        }
        
        [HttpGet("article/{articleId}")]
        public async Task<ActionResult<List<ArticleXAvailableStock>>> GetStockByArticleId(int articleId)
        {
            var articleXAvailableStock = await _articleXAvailableStockService.GetStockByArticleIdAsync(articleId);
            if (articleXAvailableStock == null)
            {
                return NotFound();
            }
            return Ok(articleXAvailableStock);
        }
        
        [HttpGet("companyStockLocation/{companyStockLocationId}")]
        public async Task<ActionResult<List<ArticleXAvailableStock>>> GetStockByCompanyStockLocationId(int companyStockLocationId)
        {
            var articleXAvailableStock = await _articleXAvailableStockService.GetStockByCompanyStockLocationIdAsync(companyStockLocationId);
            if (articleXAvailableStock == null)
            {
                return NotFound();
            }
            return Ok(articleXAvailableStock);
        }
        
        [HttpGet("availableStock/{availableStock}")]
        public async Task<ActionResult<List<ArticleXAvailableStock>>> GetStockByAvailableStock(decimal availableStock)
        {
            var articleXAvailableStock = await _articleXAvailableStockService.GetStockByAvailableStockAsync(availableStock);
            if (articleXAvailableStock == null)
            {
                return NotFound();
            }
            return Ok(articleXAvailableStock);
        }
        
        [HttpGet("minimumStock/{minimumStock}")]
        public async Task<ActionResult<List<ArticleXAvailableStock>>> GetStockByMinimumStock(decimal minimumStock)
        {
            var articleXAvailableStock = await _articleXAvailableStockService.GetStockByMinimumStockAsync(minimumStock);
            if (articleXAvailableStock == null)
            {
                return NotFound();
            }
            return Ok(articleXAvailableStock);
        }
        
        [HttpGet("maximumStock/{maximumStock}")]
        public async Task<ActionResult<List<ArticleXAvailableStock>>> GetStockByMaximumStock(decimal maximumStock)
        {
            var articleXAvailableStock = await _articleXAvailableStockService.GetStockByMaximumStockAsync(maximumStock);
            if (articleXAvailableStock == null)
            {
                return NotFound();
            }
            return Ok(articleXAvailableStock);
        }
        
        [HttpGet("actualStock/{actualStock}")]
        public async Task<ActionResult<List<ArticleXAvailableStock>>> GetStockByActualStock(decimal actualStock)
        {
            var articleXAvailableStock = await _articleXAvailableStockService.GetStockByActualStockAsync(actualStock);
            if (articleXAvailableStock == null)
            {
                return NotFound();
            }
            return Ok(articleXAvailableStock);
        }
    }

}