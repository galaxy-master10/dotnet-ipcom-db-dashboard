namespace EcommerceAdminBackend.API.Models;

using System;
using System.ComponentModel.DataAnnotations;

    public class Article
    {
        [Key]
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Application { get; set; }
        public string? ExtraInfo { get; set; }
        public string? PricingUnit { get; set; }
        public int PricingUnitId { get; set; }
        public string? PackagingUnit { get; set; }
        public int? PackagingUnitId { get; set; }
        public bool Published { get; set; }
        public Guid ProductId { get; set; }
        public string? Product { get; set; }
        public int? Index { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductGroup { get; set; }
        public string? ProductSegmentation { get; set; }
        public string? ProductType { get; set; }
        public string? CompetenceCenter { get; set; }
        public string? Sector { get; set; }
        public string? Material { get; set; }
        public decimal? Diameter { get; set; }
        public string? DiameterUnit { get; set; }
        public decimal? Length { get; set; }
        public string? LengthUnit { get; set; }
        public decimal? Thickness { get; set; }
        public string? ThicknessUnit { get; set; }
        public decimal? Width { get; set; }
        public string? WidthUnit { get; set; }
        public string? Brand { get; set; }
        public decimal? R { get; set; }
        public string? RUnit { get; set; }
        public string? Type { get; set; }
        public string? Finish { get; set; }
        public string? Color { get; set; }
        public string? FireClass { get; set; }
        public string? EdgeFinish { get; set; }
        public string? Coating { get; set; }
        public decimal? Volume { get; set; }
        public string? VolumeUnit { get; set; }
        public decimal? Weight { get; set; }
        public string? WeightUnit { get; set; }
    }
