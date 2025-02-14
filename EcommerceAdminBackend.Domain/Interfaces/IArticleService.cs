using EcommerceAdminBackend.Domain.DTOs.Filters;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Domain.Interfaces;

public interface IArticleService
{
    Task<Article?> GetByIdAsync(int id);
    Task<PaginatedResponse<Article>> GetFilteredAsync(
        ArticleFilterDto filter, int pageNumber = 1, int pageSize = 10);
}