namespace Deiarts.Tools.Terminals.MathBudget.Entities;

public class BudgetMaterial
{
    public BudgetMaterial(int budgetId, int materialId, int amount)
    {
        BudgetId = budgetId;
        MaterialId = materialId;
        Amount = amount;
    }

    public int BudgetId { get; private set; }
    public int MaterialId { get; private set; }
    public int Amount { get; private set; }

    public Budget Budget { get; private set; } = default!;
    public Material Material { get; private set; } = default!;
}