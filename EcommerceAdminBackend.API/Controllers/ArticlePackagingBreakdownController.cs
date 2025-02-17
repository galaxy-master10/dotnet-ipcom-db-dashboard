using EcommerceAdminBackend.Domain.DTOs.Filters;
using Microsoft.AspNetCore.Mvc;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;

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
        public async Task<ActionResult<PaginatedResponse<ArticlePackagingBreakdown>>> GetArticlePackagingBreakdowns(
            [FromQuery] ArticlePackagingBreakdownFilterDto filter,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _articlePackagingBreakdownService.GetFilteredAsync(filter, pageNumber, pageSize);

            if (result.Data.Count == 0)
                return NotFound("No article packaging breakdowns found matching the specified criteria.");

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticlePackagingBreakdown>> GetArticlePackagingBreakdownById(int id)
        {
            var result = await _articlePackagingBreakdownService.GetByIdAsync(id);

            if (result == null)
                return NotFound($"Article packaging breakdown with ID {id} not found.");

            return Ok(result);
        }
       
    }
}
