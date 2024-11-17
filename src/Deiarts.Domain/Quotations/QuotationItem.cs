using Menso.Tools.Exceptions;

namespace Deiarts.Domain.Quotations;

[HasPrivateEmptyConstructor]
internal partial class QuotationItem : Entity<QuotationItemId>
{
    public QuotationItem(QuotationId quotationId, ProductId productId, int quantity, decimal pricePerUnit, string description)
    {
        Throw.When.True(quantity < 1, "Quantidade deve ser maior que zero.");
        Throw.When.True(pricePerUnit <= 0, "Preço por unidade deve ser maior que zero.");
        
        QuotationId = quotationId;
        ProductId = productId;
        Quantity = quantity;
        Price = quantity * pricePerUnit;
        PricePerUnit = pricePerUnit;
        Description = description;
    }
    
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal PricePerUnit { get; private set; }
    public string Description { get; private set; }
    
    public ProductId ProductId { get; private set; }
    public QuotationId QuotationId { get; private set; }
    
    public void ChangePricing(int quantity, decimal pricePerUnit)
    {
        Throw.When.True(quantity < 1, "Quantidade deve ser maior que zero.");
        Throw.When.True(pricePerUnit <= 0, "Preço por unidade deve ser maior que zero.");
        
        Quantity = quantity;
        Price = quantity * pricePerUnit;
    }
    
    public void ChangeDescription(string description)
    {
        Description = description;
    }
}