namespace Deiarts.Tools.Terminals.MathBudget.Entities;

public class Material : Entity
{
    private readonly List<BudgetMaterial> _budgetMaterials = [];
    private readonly List<Budget> _budgets = [];
    
    public Material(string name, decimal pricePerUnit, string description)
    {
        Name = name;
        PricePerUnit = pricePerUnit;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal PricePerUnit { get;  private set; }
    
    public IEnumerable<Budget> Budgets => _budgets;
    public IEnumerable<BudgetMaterial> BudgetMaterials => _budgetMaterials;
    
    public void ChangeName(string name) => Name = name;
    public void ChangePricePerUnit(decimal pricePerUnit) => PricePerUnit = pricePerUnit;
    public void ChangeDescription(string description) => Description = description;
}