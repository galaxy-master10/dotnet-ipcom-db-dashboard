namespace EcommerceAdminBackend.Domain.DTOs.Filters;

public class ArticleFilterDto
{
     public int? Id { get; set; }
       public int? ArticleId { get; set; }
       public string? Code { get; set; }
       public string? Description { get; set; }
       public string? Application { get; set; }
       public string? ExtraInfo { get; set; }
       public string? PricingUnit { get; set; }
       public int? PricingUnitId { get; set; }
       public string? PackagingUnit { get; set; }
       public int? PackagingUnitId { get; set; }
       public bool? Published { get; set; }
       public Guid? ProductId { get; set; }
       public string? Product { get; set; }
       public int? Index { get; set; }
       public string? ProductDescription { get; set; }
       public string? ProductGroup { get; set; }
       public string? ProductSegmentation { get; set; }
       public string? ProductType { get; set; }
       public string? CompetenceCenter { get; set; }
       public string? Sector { get; set; }
       public string? Material { get; set; }
       public decimal? MinDiameter { get; set; }
       public decimal? MaxDiameter { get; set; }
       public string? DiameterUnit { get; set; }
       public decimal? MinLength { get; set; }
       public decimal? MaxLength { get; set; }
       public string? LengthUnit { get; set; }
       public decimal? MinThickness { get; set; }
       public decimal? MaxThickness { get; set; }
       public string? ThicknessUnit { get; set; }
       public decimal? MinWidth { get; set; }
       public decimal? MaxWidth { get; set; }
       public string? WidthUnit { get; set; }
       public string? Brand { get; set; }
       public decimal? MinR { get; set; }
       public decimal? MaxR { get; set; }
       public string? RUnit { get; set; }
       public string? Type { get; set; }
       public string? Finish { get; set; }
       public string? Color { get; set; }
       public string? FireClass { get; set; }
       public string? EdgeFinish { get; set; }
       public string? Coating { get; set; }
       public decimal? MinVolume { get; set; }
       public decimal? MaxVolume { get; set; }
       public string? VolumeUnit { get; set; }
       public decimal? MinWeight { get; set; }
       public decimal? MaxWeight { get; set; }
       public string? WeightUnit { get; set; }
    
}