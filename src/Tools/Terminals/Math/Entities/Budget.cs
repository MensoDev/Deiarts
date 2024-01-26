namespace Deiarts.Tools.Terminals.MathBudget.Entities;

public class Budget : Entity
{
    private readonly List<BudgetMaterial> _materialsRel = [];
    private readonly List<Material> _materials = [];
    
    
    public Budget(string client, string product, int timeServiceInMinutes)
    {
        Client = client;
        Product = product;
        TimeServiceInMinutes = timeServiceInMinutes;
    }

    public string Client { get; private set; }
    public string Product { get; private set; }
    public int TimeServiceInMinutes { get; private set; }
    
    public IEnumerable<Material> Materials => _materials;
    public IEnumerable<BudgetMaterial> MaterialsRel => _materialsRel;
    
    public void AddMaterial(Material material, int amount)
    {
        var item = new BudgetMaterial(Id, material.Id, amount);
        _materialsRel.Add(item);
        _materials.Add(material);
    }
    
    public void RemoveMaterial(Material material)
    {
        var item = _materialsRel.Find(x => x.MaterialId == material.Id);
        if (item is null) return;
        _materialsRel.Remove(item);
        _materials.Remove(material);
    }
}