namespace Daiarts.Inventory.Domain.Entities;

public sealed class Product : Entity
{
    public Product(string name, StockKeepingUnit sku, int manufacturingTime)
    {
        Name = name;
        Sku = sku;
        ManufacturingTime = manufacturingTime;
    }

    public string Name { get; private set; }
    public StockKeepingUnit Sku { get; private set; }
    public int ManufacturingTime { get; private set; }
}