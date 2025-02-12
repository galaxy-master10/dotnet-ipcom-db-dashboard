namespace EcommerceAdminBackend.API.Models;

using System.ComponentModel.DataAnnotations;


    public class ArticlePackagingBreakdown
    {
        [Key]
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string? FromUnit { get; set; }
        public int FromUnitId { get; set; }
        public decimal? FromFactor { get; set; }
        public string? ToUnit { get; set; }
        public int ToUnitId { get; set; }
        public decimal ToFactor { get; set; }
        public decimal Cubes { get; set; }
        public bool StatusInUse { get; set; }
        public bool IsERP { get; set; } = true;
        public bool IsMinimumPackaging { get; set; } = false;
    }

