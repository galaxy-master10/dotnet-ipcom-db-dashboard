using System.ComponentModel.DataAnnotations;
using EcommerceAdminBackend.Domain.DTOs.Filters;

namespace EcommerceAdminBackend.Application.Validators.Filters;

public class ArticleFilterValidator
{
   public void ValidateAndNormalize(ArticleFilterDto filter)
   {
       if (filter == null) return;

       NormalizeRanges(filter);
       ValidateRanges(filter);
   }

   private void NormalizeRanges(ArticleFilterDto filter)
   {
      
       if (filter.MinDiameter.HasValue && filter.MaxDiameter.HasValue && 
           filter.MinDiameter > filter.MaxDiameter)
           (filter.MinDiameter, filter.MaxDiameter) = (filter.MaxDiameter, filter.MinDiameter);

       
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

   private void ValidateRanges(ArticleFilterDto filter)
   {
       
       if (filter.MinDiameter.HasValue && filter.MinDiameter < 0)
           throw new ValidationException("MinDiameter cannot be negative");

       if (filter.MinLength.HasValue && filter.MinLength < 0)
           throw new ValidationException("MinLength cannot be negative");

       if (filter.MinThickness.HasValue && filter.MinThickness < 0)
           throw new ValidationException("MinThickness cannot be negative");

       if (filter.MinWidth.HasValue && filter.MinWidth < 0)
           throw new ValidationException("MinWidth cannot be negative");

       if (filter.MinVolume.HasValue && filter.MinVolume < 0)
           throw new ValidationException("MinVolume cannot be negative");

       if (filter.MinWeight.HasValue && filter.MinWeight < 0)
           throw new ValidationException("MinWeight cannot be negative");

       if (filter.MinR.HasValue && filter.MinR < 0)
           throw new ValidationException("MinR cannot be negative");
   }
}