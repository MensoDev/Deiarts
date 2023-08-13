namespace Deiarts.Prototype.Domain.ValueObjects;

public class StockKeepingUnit : ValueObject
{
    public StockKeepingUnit(string brand, string model, string material, string color)
    {
        Brand = brand;
        Model = model;
        Material = material;
        Color = color;
        
        AddNotifications(DomainNotifications
            .Rules
            .Requires()
            .IsNotNullOrWhiteSpace(brand, nameof(Brand), "Brand is required")
            .IsNotNullOrWhiteSpace(model, nameof(Model), "Model is required")
            .IsNotNullOrWhiteSpace(material, nameof(Material), "Material is required")
            .IsNotNullOrWhiteSpace(color, nameof(Color), "Color is required")
        );
    }

    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Material { get; private set; }
    public string Color { get; private set; }


    public override string ToString() => $"{Brand}-{Model}-{Material}-{Color}";
}