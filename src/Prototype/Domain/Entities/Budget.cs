namespace Deiarts.Prototype.Domain.Entities;

public sealed class Budget : Entity
{
    private readonly List<BudgetItem> _items = new();

    public Budget(string title, string description, DateTimeOffset validity)
    {
        Title = title;
        Description = description;
        Validity = validity;
        Status = BudgetStatus.Draft;
        
        AddNotifications(DomainNotifications
            .Rules
            .Requires()
            .IsNotNullOrEmpty(Title, nameof(Title), "Title is required")
            .IsNotNullOrEmpty(Description, nameof(Description), "Description is required")
            .IsGreaterThan(Validity.DateTime, DateTimeOffset.UtcNow.DateTime, nameof(Validity), "Validity must be greater than now")
        );
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTimeOffset Validity { get; private set; }
    public BudgetStatus Status { get; private set; }

    public IEnumerable<BudgetItem> Items => _items.AsReadOnly();
    
    public void AddItem(BudgetItem item)
    {
        Throw<DomainException>.When.True(Id != item.BudgetId, "Item must belong to this budget");
        AddNotifications(item);
        _items.Add(item);
    }
    
}