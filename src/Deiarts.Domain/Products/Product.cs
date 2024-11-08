using Deiarts.Domain.RawMaterials;

namespace Deiarts.Domain.Products;

[HasPrivateEmptyConstructor]
internal partial class Product : Entity<ProductId>, IAggregateRoot
{
    private readonly List<ProductComposition> _compositions = [];

    public Product(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public IReadOnlyList<ProductComposition> Compositions => _compositions.AsReadOnly();
    
    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void ChangeComposition(RawMaterialId rawMaterialId, string description, int quantity)
    {
        var composition = _compositions.FirstOrDefault(c => c.RawMaterialId == rawMaterialId);
        
        if (composition is not null)
        {
            composition.ChangeDescription(description);
            composition.ChangeQuantity(quantity);
            return;
        }
        
        _compositions.Add(new ProductComposition(Id, rawMaterialId, description, quantity));
    }
    
    public void RemoveCompositions(ProductCompositionId[] compositionIds)
    {
        _compositions.RemoveAll(composition => compositionIds.Contains(composition.Id));
    }
    
}