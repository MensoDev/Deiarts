namespace Deiarts.Domain.Products;

[HasPrivateEmptyConstructor]
internal partial class ProductComposition : Entity<ProductCompositionId>
{
    public ProductComposition(ProductId productId, RawMaterialId rawMaterialId, string description, int quantity)
    {
        ProductId = productId;
        RawMaterialId = rawMaterialId;
        Description = description;
        Quantity = quantity;
    }
    
    public ProductId ProductId { get; private set; }
    public RawMaterialId RawMaterialId { get; private set; }
    
    public string Description { get; private set; }
    public int Quantity { get; private set; }
    
    public void ChangeDescription(string description) => Description = description;
    public void ChangeQuantity(int quantity) => Quantity = quantity;
}