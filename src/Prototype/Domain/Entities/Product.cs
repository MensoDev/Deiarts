using Deiarts.Prototype.Domain.ValueObjects;

namespace Deiarts.Prototype.Domain.Entities;

public sealed class Product : Entity
{
    public Product(string name, StockKeepingUnit sku, int manufacturingTime, Image image)
    {
        Name = name;
        Sku = sku;
        ManufacturingTime = manufacturingTime;
        Image = image;
    }

    public string Name { get; private set; }
    public StockKeepingUnit Sku { get; private set; }
    public int ManufacturingTime { get; private set; }
    
    public Image Image { get; private set; }
}