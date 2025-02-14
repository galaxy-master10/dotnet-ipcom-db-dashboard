namespace EcommerceAdminBackend.Domain.DTOs.Custom;

public class CustomerDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CustomerContactId { get; set; }
    public string? SourceId { get; set; }
    public string? CustomerName { get; set; }
    public string? AddressStreet { get; set; }
    public string? AddressNumber { get; set; }
    public string? AddressPostalCode { get; set; }
    public string? AddressCity { get; set; }
    public string? AddressCountry { get; set; }
    public string? Web { get; set; }
    public string? VatNumber { get; set; }
    public string? FirstName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Language { get; set; }
    public string? Mobile { get; set; }
    public DateTime? CreatedTS { get; set; }
}