using Deiarts.Application.Quotations.GetItem;

namespace Deiarts.Application.Quotations.EditeItem;

public class EditQuotationItemRequest
{
    public QuotationId Id { get; set; }
    public QuotationItemId? ItemId { get; set; }
    
    public ProductId? ProductId { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; }
    
    public void CopyFrom(GetQuotationItemResponse response)
    {
        Id = response.Id;
        ItemId = response.ItemId;
        ProductId = response.ProductId;
        Description = response.Description;
        Quantity = response.Quantity;
    }
    
}