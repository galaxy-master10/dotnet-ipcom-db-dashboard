using EcommerceAdminBackend.Domain.DTOs;
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
        public async Task<ActionResult<PaginatedResponse<ArticleXAvailableStock>>> GetArticleXAvailableStocks(
            [FromQuery] ArticleXAvailableStockFilterDto filter,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _articleXAvailableStockService.GetFilteredAsync(filter, pageNumber, pageSize);
           if (result.Data.Count == 0)
                return NotFound("No article available stock found matching the specified criteria.");

            return Ok(result);
            
        }
        
        [HttpGet("{articleId}/{companyStockLocationId}")]
        public async Task<ActionResult<ArticleXAvailableStock>> GetArticleXAvailableStock(
            int articleId, 
            int companyStockLocationId)
        {
            var articleXAvailableStock = await _articleXAvailableStockService.GetAvailableStockByIdAsync(
                articleId, 
                companyStockLocationId);

            if (articleXAvailableStock == null)
            {
                return NotFound();
            }

            return Ok(articleXAvailableStock);
        }
    }
}