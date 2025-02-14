using EcommerceAdminBackend.Domain.DTOs.Filters;
using EcommerceAdminBackend.Domain.Entities;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;

namespace EcommerceAdminBackend.Application.Services;

public class ArticleService : IArticleService
{
     private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
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
            // Validate input
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            
            // Apply basic validation on filter
            if (filter != null)
            {
                // Ensure numerical ranges are valid
                if (filter.MinDiameter.HasValue && filter.MaxDiameter.HasValue && 
                    filter.MinDiameter > filter.MaxDiameter)
                    (filter.MinDiameter, filter.MaxDiameter) = (filter.MaxDiameter, filter.MinDiameter);

                // Similar validations for other numerical ranges
                ValidateRanges(filter);
            }

            var (items, totalCount) = await _articleRepository.GetFilteredAsync(filter, pageNumber, pageSize);

            return new PaginatedResponse<Article>(items, pageNumber, pageSize, totalCount);
        }

        private void ValidateRanges(ArticleFilterDto filter)
        {
            if (filter.MinLength.HasValue && filter.MaxLength.HasValue && 
                filter.MinLength > filter.MaxLength)
                (filter.MinLength, filter.MaxLength) = (filter.MaxLength, filter.MinLength);

            if (filter.MinThickness.HasValue && filter.MaxThickness.HasValue && 
                filter.MinThickness > filter.MaxThickness)
                (filter.MinThickness, filter.MaxThickness) = (filter.MaxThickness, filter.MinThickness);

            if (filter.MinWidth.HasValue && filter.MaxWidth.HasValue && 
                filter.MinWidth > filter.MaxWidth)
                (filter.MinWidth, filter.MaxWidth) = (filter.MaxWidth, filter.MinWidth);

            if (filter.MinVolume.HasValue && filter.MaxVolume.HasValue && 
                filter.MinVolume > filter.MaxVolume)
                (filter.MinVolume, filter.MaxVolume) = (filter.MaxVolume, filter.MinVolume);

            if (filter.MinWeight.HasValue && filter.MaxWeight.HasValue && 
                filter.MinWeight > filter.MaxWeight)
                (filter.MinWeight, filter.MaxWeight) = (filter.MaxWeight, filter.MinWeight);

            if (filter.MinR.HasValue && filter.MaxR.HasValue && 
                filter.MinR > filter.MaxR)
                (filter.MinR, filter.MaxR) = (filter.MaxR, filter.MinR);
        }
}