namespace EcommerceAdminBackend.API.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class ArticleXAvailableStock
    {
        [Key, Column(Order = 1)]
        public int ArticleId { get; set; }
        
        [Key, Column(Order = 2)]
        public int CompanyStockLocationId { get; set; }
        
        public decimal AvailableStock { get; set; } = 0;
        public decimal? MinimumStock { get; set; }
        public decimal? MaximumStock { get; set; }
        public decimal? ActualStock { get; set; }
    }

