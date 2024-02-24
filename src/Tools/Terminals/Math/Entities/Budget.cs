namespace Deiarts.Tools.Terminals.MathBudget.Entities;

public class Budget : Entity
{
    private readonly List<BudgetMaterial> _budgetMaterials = [];
    private readonly List<Material> _materials = [];
    
    public Budget(string product, int timeServiceInMinutes)
    {
        Product = product;
        TimeServiceInMinutes = timeServiceInMinutes;
    }
    
    public string Product { get; private set; }
    public int TimeServiceInMinutes { get; private set; }
    
    public IEnumerable<Material> Materials => _materials;
    public IEnumerable<BudgetMaterial> BudgetMaterials => _budgetMaterials;
    
    public void AddMaterial(Material material, int amount)
    {
        var item = new BudgetMaterial(Id, material.Id, amount);
        _budgetMaterials.Add(item);
        _materials.Add(material);
    }
    
    public void RemoveMaterial(Material material)
    {
        var item = _budgetMaterials.Find(x => x.MaterialId == material.Id);
        if (item is null) return;
        _budgetMaterials.Remove(item);
        _materials.Remove(material);
    }
}