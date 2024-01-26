namespace Deiarts.Tools.Terminals.MathBudget.Commands.Materials.Parameters;

public record CreateMaterialParameters : ICommandParameterSet
{
    [Option("nome", [ 'n' ] , Description = "Nome do material usado em orçamentos")]
    public string Name { get; set; } = string.Empty;
    
    [Option("preco", [ 'p' ] , Description = "Preço por unidade do material usado em orçamentos")]
    public decimal PricePerUnit { get; set; }
    
    [Option("descricao", [ 'd' ] , Description = "Descrição do material usado em orçamentos")]
    public string Description { get; set; } = string.Empty;
}