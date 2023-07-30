namespace Daiarts.Inventory.Domain.Entities;

public sealed class Feedstock : Entity
{
    public Feedstock(string name, string description, UnitOfMeasurement unitOfMeasurement, decimal quantity)
    {
        Name = name;
        Description = description;
        UnitOfMeasurement = unitOfMeasurement;
        Quantity = quantity;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public UnitOfMeasurement UnitOfMeasurement { get; private set; }
    public decimal Quantity { get; private set; }
}