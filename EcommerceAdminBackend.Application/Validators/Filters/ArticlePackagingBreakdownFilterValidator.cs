using System.ComponentModel.DataAnnotations;
using EcommerceAdminBackend.Domain.DTOs.Filters;

namespace EcommerceAdminBackend.Application.Validators.Filters;

public class ArticlePackagingBreakdownFilterValidator
{
    public void ValidateAndNormalize(ArticlePackagingBreakdownFilterDto filter)
    {
        if (filter == null) return;

        NormalizeRanges(filter);
        ValidateRanges(filter);
    }

    private void NormalizeRanges(ArticlePackagingBreakdownFilterDto filter)
    {
        if (filter.MinFromFactor.HasValue && filter.MaxFromFactor.HasValue && 
            filter.MinFromFactor > filter.MaxFromFactor)
            (filter.MinFromFactor, filter.MaxFromFactor) = (filter.MaxFromFactor, filter.MinFromFactor);

        if (filter.MinToFactor.HasValue && filter.MaxToFactor.HasValue && 
            filter.MinToFactor > filter.MaxToFactor)
            (filter.MinToFactor, filter.MaxToFactor) = (filter.MaxToFactor, filter.MinToFactor);

        if (filter.MinCubes.HasValue && filter.MaxCubes.HasValue && 
            filter.MinCubes > filter.MaxCubes)
            (filter.MinCubes, filter.MaxCubes) = (filter.MaxCubes, filter.MinCubes);
    }

    private void ValidateRanges(ArticlePackagingBreakdownFilterDto filter)
    {
        // Add any additional validation rules
        if (filter.MinFromFactor.HasValue && filter.MinFromFactor < 0)
            throw new ValidationException("MinFromFactor cannot be negative");
            
        if (filter.MinToFactor.HasValue && filter.MinToFactor < 0)
            throw new ValidationException("MinToFactor cannot be negative");
            
        if (filter.MinCubes.HasValue && filter.MinCubes < 0)
            throw new ValidationException("MinCubes cannot be negative");
    }
}