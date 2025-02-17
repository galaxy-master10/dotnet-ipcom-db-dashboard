using System.ComponentModel.DataAnnotations;
using EcommerceAdminBackend.Domain.DTOs.Custom;

namespace EcommerceAdminBackend.Application.Validators.Filters;

public class CustomerFilterValidator
{
   public void ValidateAndNormalize(CustomerFilterDto filter, int pageNumber, int pageSize)
   {
       if (filter == null) return;

       ValidatePagination(ref pageNumber, ref pageSize);
       ValidateFilter(filter);
       NormalizeFilter(filter);
   }

   private void ValidatePagination(ref int pageNumber, ref int pageSize)
   {
       pageNumber = Math.Max(1, pageNumber);
       pageSize = Math.Max(1, Math.Min(pageSize, 100)); 
   }

   private void ValidateFilter(CustomerFilterDto filter)
   {
      
       if (filter.Id.HasValue && filter.Id <= 0)
           throw new ValidationException("Id must be positive");

       if (filter.CustomerId.HasValue && filter.CustomerId <= 0)
           throw new ValidationException("CustomerId must be positive");

       if (filter.CustomerContactId.HasValue && filter.CustomerContactId <= 0)
           throw new ValidationException("CustomerContactId must be positive");

      
       if (!string.IsNullOrEmpty(filter.Email) && !IsValidEmail(filter.Email))
           throw new ValidationException("Invalid email format");

     
       if (!string.IsNullOrEmpty(filter.Mobile) && !IsValidPhoneNumber(filter.Mobile))
           throw new ValidationException("Invalid mobile number format");

       
       if (filter.CreatedTS.HasValue && filter.CreatedTS > DateTime.UtcNow)
           throw new ValidationException("CreatedTS cannot be in the future");
   }

   private void NormalizeFilter(CustomerFilterDto filter)
   {
      
       filter.Email = filter.Email?.Trim().ToLower();
       filter.Mobile = filter.Mobile?.Trim();
       filter.VatNumber = filter.VatNumber?.Trim().ToUpper();
       filter.Language = filter.Language?.Trim().ToUpper();

      
       filter.AddressPostalCode = filter.AddressPostalCode?.Trim().ToUpper();
       filter.AddressCity = filter.AddressCity?.Trim();
       filter.AddressCountry = filter.AddressCountry?.Trim().ToUpper();
   }

   private bool IsValidEmail(string email)
   {
       try
       {
           var addr = new System.Net.Mail.MailAddress(email);
           return addr.Address == email;
       }
       catch
       {
           return false;
       }
   }

   private bool IsValidPhoneNumber(string phoneNumber)
   {
       
       return System.Text.RegularExpressions.Regex.IsMatch(
           phoneNumber, 
           @"^\+?[0-9]\d{1,14}$"
       );
   }
}