namespace EcommerceAdminBackend.Domain.DTOs;

public class ArticleXAvailableStockFilterDto
{
    public int? ArticleId { get; set; }
    public int? CompanyStockLocationId { get; set; }
    public decimal? MinAvailableStock { get; set; }
    public decimal? MaxAvailableStock { get; set; }
    public decimal? MinimumStock { get; set; }
    public decimal? MaximumStock { get; set; }
    public decimal? ActualStock { get; set; }
}