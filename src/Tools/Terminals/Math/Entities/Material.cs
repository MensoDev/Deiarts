namespace Deiarts.Tools.Terminals.MathBudget.Entities;

public class Material : Entity
{
    public Material(string name, decimal pricePerUnit, string description)
    {
        Name = name;
        PricePerUnit = pricePerUnit;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal PricePerUnit { get;  private set; }
    
    public void ChangeName(string name) => Name = name;
    public void ChangePricePerUnit(decimal pricePerUnit) => PricePerUnit = pricePerUnit;
    public void ChangeDescription(string description) => Description = description;
}