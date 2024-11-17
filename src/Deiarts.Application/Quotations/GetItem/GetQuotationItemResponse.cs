namespace Deiarts.Application.Quotations.GetItem;

public class GetQuotationItemResponse
{
    public required QuotationId Id { get; init; }
    public required QuotationItemId? ItemId { get; init; }
    
    public required ProductId? ProductId { get; init; }
    public required string Description { get; init; }
    public required int Quantity { get; init; }
}