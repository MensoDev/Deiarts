namespace Deiarts.Prototype.Domain.Entities;

public class Product : Entity
{
    private readonly List<ProductMaterial> _productMaterials = [];
    private readonly List<Material> _materials = [];
    
    private readonly List<BudgetProduct> _budgetProducts = [];
    private readonly List<Budget> _budgets = [];
    
    public Product(string name, string description, TimeSpan laborTime)
    {
        Name = name;
        Description = description;
        LaborTime = laborTime;
        
        Throw.When.Null(name, "Name is required");
        Throw.When.Null(description, "Description is required");
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public TimeSpan LaborTime { get; private set; }
    
    public IEnumerable<Material> Materials => _materials;
    public IEnumerable<ProductMaterial> ProductMaterials => _productMaterials;
    
    public IEnumerable<Budget> Budgets => _budgets;
    public IEnumerable<BudgetProduct> BudgetProducts => _budgetProducts;
    
    public void AddMaterial(Material material, int amount)
    {
        var item = new ProductMaterial(Id, material.Id, amount);
        _productMaterials.Add(item);
        _materials.Add(material);
    }
    
    public void RemoveMaterial(Material material)
    {
        var item = _productMaterials.Find(x => x.MaterialId == material.Id);
        if (item is null) return;
        _productMaterials.Remove(item);
        _materials.Remove(material);
    }
}