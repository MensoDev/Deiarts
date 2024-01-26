using Deiarts.Tools.Terminals.MathBudget.Commands.Materials.Parameters;
using Deiarts.Tools.Terminals.MathBudget.Data;
using Deiarts.Tools.Terminals.MathBudget.Entities;
using Microsoft.EntityFrameworkCore;

namespace Deiarts.Tools.Terminals.MathBudget.Commands.Materials;

public class MaterialCommands
{
    [Command("novo", Description = "Cria um novo material")]
    public async Task Create(CreateMaterialParameters parameters, [FromService] MathBudgetDbContext context)
    {
        var material = new Material(parameters.Name, parameters.PricePerUnit, parameters.Description);
        context.Materials.Add(material);
        await context.SaveChangesAsync();
        
        Alert.WriteSuccess($"Material '{material.Name}' criado com sucesso!");
    }
    
    [Command("listar", Description = "Listar todos os matérias")]
    public async Task ListAll([FromService] MathBudgetDbContext context, [Option] string? termo = "")
    {
        var materials = await context
            .Materials
            .AsNoTracking()
            .Where(m => m.Name.Contains(termo!) || m.Description.Contains(termo!))
            .ToArrayAsync();
        
        Printer.Clear();
        Printer.PrintHeader("Materiais");

        foreach (var material in materials)
        {
            PrintMaterial(material);
        }
        
        Printer.PrintFooter();
    }
    
    [Command("editar", Description = "Editar um material")]
    public async Task Edit(EditMaterialParameters parameters, [FromService] MathBudgetDbContext context, [Argument("Id")] int id)
    {
        var material = await context.Materials.FindAsync(id);
        
        if (material is null)
        {
            Alert.WriteError($"Material com ID '{id}' não encontrado!");
            return;
        }
        
        Printer.PrintHeader($"Editando o Material {material.Id}");

        if (!string.IsNullOrWhiteSpace(parameters.Name)) { material.ChangeName(parameters.Name); }
        if (!string.IsNullOrWhiteSpace(parameters.Description)) { material.ChangeDescription(parameters.Description); }
        if (parameters.PricePerUnit.HasValue) { material.ChangePricePerUnit(parameters.PricePerUnit.Value); }
        
        PrintMaterial(material);
        
        Printer.WriteDashedLine();
        Printer.NewLine();
        
        var confirm = Printer.Confirm("Deseja confirmar a alteração? (S/N)");
        
        if (!confirm)
        {
            Alert.WriteInfo("Operação cancelada!");
            return;
        }
        
        await context.SaveChangesAsync();
        
        Alert.WriteSuccess($"Material '{material.Name}' editado com sucesso!");
    }
    
    private static void PrintMaterial(Material material)
    {
        Printer.PrintInfo("Material ID", material.Id.ToString(), ConsoleColor.Yellow);
        Printer.PrintInfo("Nome", material.Name);
        Printer.PrintCurrencyInfo("Preço por unidade", material.PricePerUnit, ConsoleColor.Yellow);
        Printer.PrintInfo("Descrição", material.Description);
        Printer.WriteDashedLine();
        Printer.NewLine();
    }
}