namespace EcommerceAdminBackend.Domain.DTOs.Filters;

public class ArticlePackagingBreakdownFilterDto
{
    public int? Id { get; set; }
    public int? ArticleId { get; set; }
    public string? FromUnit { get; set; }
    public int? FromUnitId { get; set; }
    public decimal? MinFromFactor { get; set; }
    public decimal? MaxFromFactor { get; set; }
    public string? ToUnit { get; set; }
    public int? ToUnitId { get; set; }
    public decimal? MinToFactor { get; set; }
    public decimal? MaxToFactor { get; set; }
    public decimal? MinCubes { get; set; }
    public decimal? MaxCubes { get; set; }
    public bool? StatusInUse { get; set; }
    public bool? IsERP { get; set; }
    public bool? IsMinimumPackaging { get; set; }
}