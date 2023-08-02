namespace Daiarts.Inventory.Domain.ValueObjects;

public record struct StockKeepingUnit
{
    public StockKeepingUnit(string brand, string model, string material, string color)
    {
        Brand = brand;
        Model = model;
        Material = material;
        Color = color;
    }

    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Material { get; private set; }
    public string Color { get; private set; }

    public override string ToString() => $"{Brand}-{Model}-{Material}-{Color}";
}