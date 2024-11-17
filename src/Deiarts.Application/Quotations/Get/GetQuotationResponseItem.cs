namespace Deiarts.Application.Quotations.Get;

public class GetQuotationResponseItem
{
    public required QuotationItemId Id { get; set; }
    
    public required string ProductName { get; set; }
    
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
    public required decimal PricePerUnit { get; set; }
    
    public required string Description { get; set; }
    
}