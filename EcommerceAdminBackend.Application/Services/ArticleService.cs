using EcommerceAdminBackend.Application.Validators.Filters;
using EcommerceAdminBackend.Domain.DTOs.Filters;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Application.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;
    private readonly ArticleFilterValidator _filterValidator;

    public ArticleService(
        IArticleRepository articleRepository,
        ArticleFilterValidator filterValidator)
    {
        _articleRepository = articleRepository;
        _filterValidator = filterValidator;
    }

        public async Task<Article?> GetByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _articleRepository.GetByIdAsync(id);
        }

        public async Task<PaginatedResponse<Article>> GetFilteredAsync(
            ArticleFilterDto filter, int pageNumber = 1, int pageSize = 10)
        {
            
            pageNumber = Math.Max(1, pageNumber);
            pageSize = Math.Max(1, Math.Min(pageSize, 100)); 

            
            _filterValidator.ValidateAndNormalize(filter);

            var (items, totalCount) = await _articleRepository.GetFilteredAsync(filter, pageNumber, pageSize);

            return new PaginatedResponse<Article>(items, pageNumber, pageSize, totalCount);
        }

       
}