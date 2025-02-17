using System.ComponentModel.DataAnnotations;
using EcommerceAdminBackend.Domain.DTOs;

namespace EcommerceAdminBackend.Application.Validators.Filters;

public class ArticleXAvailableStockFilterValidator
{
   public void ValidateAndNormalize(ArticleXAvailableStockFilterDto filter, int pageNumber, int pageSize)
   {
       if (filter == null) return;

       ValidatePagination(ref pageNumber, ref pageSize);
       NormalizeRanges(filter);
       ValidateRanges(filter);
   }

   private void ValidatePagination(ref int pageNumber, ref int pageSize)
   {
       pageNumber = Math.Max(1, pageNumber);
       pageSize = Math.Max(1, Math.Min(pageSize, 100)); 
   }

   private void NormalizeRanges(ArticleXAvailableStockFilterDto filter)
   {
       if (filter.MinAvailableStock.HasValue && filter.MaxAvailableStock.HasValue &&
           filter.MinAvailableStock > filter.MaxAvailableStock)
           (filter.MinAvailableStock, filter.MaxAvailableStock) = 
               (filter.MaxAvailableStock, filter.MinAvailableStock);

       

       if (filter.MinimumStock.HasValue && filter.MaximumStock.HasValue &&
           filter.MinimumStock > filter.MaximumStock)
           (filter.MinimumStock, filter.MaximumStock) = 
               (filter.MaximumStock, filter.MinimumStock);
   }

   private void ValidateRanges(ArticleXAvailableStockFilterDto filter)
   {
      
       if (filter.MinAvailableStock.HasValue && filter.MinAvailableStock < 0)
           throw new ValidationException("MinAvailableStock cannot be negative");

       
       if (filter.MinimumStock.HasValue && filter.MinimumStock < 0)
           throw new ValidationException("MinimumStock cannot be negative");

       if (filter.ArticleId.HasValue && filter.ArticleId <= 0)
           throw new ValidationException("ArticleId must be positive");

       if (filter.CompanyStockLocationId.HasValue && filter.CompanyStockLocationId <= 0)
           throw new ValidationException("CompanyStockLocationId must be positive");
   }
}
