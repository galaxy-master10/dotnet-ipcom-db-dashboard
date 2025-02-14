using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceAdminBackend.Domain.DTOs.Filters;
using EcommerceAdminBackend.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Shared.Common.Utilities;

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
        public async Task<ActionResult<PaginatedResponse<Article>>> GetArticles(
            [FromQuery] ArticleFilterDto filter,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _articleService.GetFilteredAsync(filter, pageNumber, pageSize);
    
            if (result.Data.Count == 0)
                return NotFound("No articles found matching the specified criteria.");

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _articleService.GetByIdAsync(id);
            
            if (article == null)
                return NotFound($"Article with ID {id} not found.");

            return Ok(article);
        }
        
        
        
    }
}
