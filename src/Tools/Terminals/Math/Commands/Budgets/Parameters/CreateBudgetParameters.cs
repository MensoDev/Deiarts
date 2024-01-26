namespace Deiarts.Tools.Terminals.MathBudget.Commands.Budgets.Parameters;

public class CreateBudgetParameters : ICommandParameterSet
{
    [Option("cliente", ['c'], Description = "Nome do cliente")]
    public string Client { get; set; } = string.Empty;
    
    [Option("produto", ['p'], Description = "Nome do produto")]
    public string Product { get; set; } = string.Empty;
    
    [Option("tempo", ['t'], Description = "Tempo de serviço em minutos")]
    public int TimeServiceInMinutes { get; set; }
}