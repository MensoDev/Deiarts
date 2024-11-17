namespace Deiarts.Application.Quotations.RemoveItem;

public class RemoveQuotationItemRequest
{
    public QuotationId Id { get; set; }
    public QuotationItemId ItemId { get; set; }
}