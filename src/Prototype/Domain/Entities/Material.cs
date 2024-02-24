namespace Deiarts.Prototype.Domain.Entities;

public class Material : Entity
{
    private readonly List<ProductMaterial> _productMaterials = [];
    private readonly List<Product> _products = [];

    public Material(string name, decimal pricePerUnit, string description)
    {
        Name = name;
        PricePerUnit = pricePerUnit;
        Description = description;
        
        Throw.When.Null(name, "Name is required");
        Throw.When.Null(description, "Description is required");
        //Throw.When.ZeroOrNegative(pricePerUnit, "Price per unit must be greater than zero");
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal PricePerUnit { get; private set; }

    public IEnumerable<Product> Products => _products;
    public IEnumerable<ProductMaterial> ProductMaterials => _productMaterials;

    public void Update(string name, decimal pricePerUnit, string description)
    {
        Name = name;
        PricePerUnit = pricePerUnit;
        Description = description;
    }
}