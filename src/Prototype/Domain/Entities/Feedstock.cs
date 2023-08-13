namespace Deiarts.Prototype.Domain.Entities;

public sealed class Feedstock : Entity
{
    private readonly IList<Batch> _batches = new List<Batch>();
    
    public Feedstock(string name, string description, UnitOfMeasurement unitOfMeasurement, decimal quantity, Image image)
    {
        Name = name;
        Description = description;
        UnitOfMeasurement = unitOfMeasurement;
        Quantity = quantity;
        Image = image;
        
        AddNotifications(DomainNotifications
            .Rules
            .Requires()
            .IsNotNullOrEmpty(Name, nameof(Name), "Name is required")
            .IsNotNullOrEmpty(Description, nameof(Description), "Description is required")
            .IsGreaterThan(Quantity, 0, nameof(Quantity), "Quantity must be greater than 0")
        );
        
        AddNotifications(image);
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public UnitOfMeasurement UnitOfMeasurement { get; private set; }
    public decimal Quantity { get; private set; }
    public Image Image { get; private set; }
    public IEnumerable<Batch> Batches => _batches.AsReadOnly();
}