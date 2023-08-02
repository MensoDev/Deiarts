namespace Daiarts.Sales.Domain.Entities;

public class Budget : Entity
{
    private readonly List<BudgetItem> _items = new();

    public Budget(string title, string description, DateTime validity)
    {
        Title = title;
        Description = description;
        Validity = validity;
        Status = BudgetStatus.Draft;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Validity { get; private set; }
    public BudgetStatus Status { get; private set; }

    public IReadOnlyCollection<BudgetItem> Items => _items.AsReadOnly();
    
    public void AddItem(Guid productId, decimal quantity)
    {
        _items.Add(new BudgetItem(Id, productId, quantity));
    }
    
}