namespace Deiarts.Application.Quotations.Get;

public class GetQuotationResponse
{
    public required QuotationId Id { get; set; }
    
    public required string Title { get; set; }
    public required string Description { get; set; }
    
    public required string CustomerName { get; set; }
    public required string CustomerEmail { get; set; }
    public required string CustomerPhone { get; set; }
    
    public required GetQuotationResponseItem[] Items { get; set; }
}