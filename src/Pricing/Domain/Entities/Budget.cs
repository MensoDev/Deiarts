namespace Daiarts.Pricing.Domain.Entities;

public class Budget : Entity
{
    private readonly List<BudgetItem> _items = new();
    
    public IReadOnlyCollection<BudgetItem> Items => _items.AsReadOnly();
    
    public void AddItem(Guid productId, decimal quantity)
    {
        _items.Add(new BudgetItem(Id, productId, quantity));
    }
}