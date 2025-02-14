
using EcommerceAdminBackend.Domain.DTOs.Filters;
using EcommerceAdminBackend.Domain.Entities;

namespace EcommerceAdminBackend.Domain.Interfaces;

public interface IArticleRepository
{
 
    Task<Article?> GetByIdAsync(int id);
    Task<(List<Article> Items, int TotalCount)> GetFilteredAsync(
        ArticleFilterDto filter, int pageNumber, int pageSize);
    
}