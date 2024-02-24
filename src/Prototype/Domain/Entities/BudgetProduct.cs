namespace Deiarts.Prototype.Domain.Entities;

public class BudgetProduct
{
    public BudgetProduct(Guid budgetId, Guid productId, int amount)
    {
        BudgetId = budgetId;
        ProductId = productId;
        Amount = amount;

        Throw.When.Empty(budgetId, "Budget is required");
        Throw.When.Empty(productId, "Product is required");
    }

    public Guid BudgetId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Amount { get; private set; }

    public Product Product { get; private set; } = default!;
    public Material Material { get; private set; } = default!;
}