using Cocona;

namespace Deiarts.Tools.Terminals.MathBudget.Commands.Materials.Parameters;

public record CreateMaterialParameters : ICommandParameterSet
{
    [Option("name", [ 'n' ] , Description = "Nome do material usado em orçamentos")]
    public string Name { get; set; } = string.Empty;
    
    [Option("price", [ 'p' ] , Description = "Preço por unidade do material usado em orçamentos")]
    public decimal PricePerUnit { get; set; }
    
    [Option("description", [ 'd' ] , Description = "Descrição do material usado em orçamentos")]
    public string Description { get; set; } = string.Empty;
}