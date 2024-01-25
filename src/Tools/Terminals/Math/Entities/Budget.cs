namespace Deiarts.Tools.Terminals.MathBudget.Entities;

public class Budget : Entity
{
    private readonly List<BudgetMaterial> _materials = [];
    
    public Budget(string name, string client, string product, int timeServiceInMinutes)
    {
        Name = name;
        Client = client;
        Product = product;
        TimeServiceInMinutes = timeServiceInMinutes;
    }

    public string Name { get; private set; }
    public string Client { get; private set; }
    public string Product { get; private set; }
    public int TimeServiceInMinutes { get; private set; }
    
    public IEnumerable<BudgetMaterial> Materials => _materials;
    
    public void AddMaterial(Material material, int amount)
    {
        var item = new BudgetMaterial(Id, material.Id, amount);
        _materials.Add(item);
    }
    
    public void RemoveMaterial(Material material)
    {
        var item = _materials.Find(x => x.MaterialId == material.Id);
        if (item is not null)
        {
            _materials.Remove(item);
        }
    }
}