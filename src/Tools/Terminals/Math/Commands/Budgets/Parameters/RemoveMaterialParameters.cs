namespace Deiarts.Tools.Terminals.MathBudget.Commands.Budgets.Parameters;

public class RemoveMaterialParameters : ICommandParameterSet
{
    [Argument("orcamento", Description = "Id do orçamento/produto")]
    public int BudgetId { get; set; }
    
    [Option("material", ['m'],  Description = "Id do material")]
    public int MaterialId { get; set; }
}