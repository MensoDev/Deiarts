

namespace Deiarts.Tools.Terminals.MathBudget.Commands.Materials.Parameters;

public class EditMaterialParameters : ICommandParameterSet
{
    [Option("nome", ['n'], Description = "Nome do material usado em orçamentos")]
    [HasDefaultValue]
    public string? Name { get; set; } = string.Empty;

    [Option("preco", ['p'], Description = "Preço por unidade do material usado em orçamentos")]
    [HasDefaultValue]
    public decimal? PricePerUnit { get; set; } = null;

    [Option("descricao", ['d'], Description = "Descrição do material usado em orçamentos")]
    [HasDefaultValue]
    public string? Description { get; set; } = string.Empty;
}