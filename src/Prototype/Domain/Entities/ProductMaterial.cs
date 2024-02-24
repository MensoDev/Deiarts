namespace Deiarts.Prototype.Domain.Entities;

public class ProductMaterial
{
    public ProductMaterial(Guid productId, Guid materialId, int amount)
    {
        ProductId = productId;
        MaterialId = materialId;
        Amount = amount;
    }

    public Guid ProductId { get; private set; }
    public Guid MaterialId { get; private set; }
    public int Amount { get; private set; }

    public Product Product { get; private set; } = default!;
    public Material Material { get; private set; } = default!;
}