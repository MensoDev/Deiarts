namespace Daiarts.Pricing.Domain.Entities;

public class BudgetItem : Entity
{
    public BudgetItem(Guid budgetId, Guid productId, decimal quantity)
    {
        BudgetId = budgetId;
        ProductId = productId;
        Quantity = quantity;
    }

    public Guid BudgetId { get; private set; }
    public Guid ProductId { get; private set; }
    public decimal Quantity { get; private set; }
}