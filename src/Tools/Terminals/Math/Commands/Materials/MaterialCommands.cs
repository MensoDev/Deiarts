using Cocona;
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
    }
    
    [Command("listar", Description = "Listar todos os matérias")]
    public async Task ListAll([FromService] MathBudgetDbContext context, [Option] string? termo = "")
    {
        var materials = await context
            .Materials
            .AsNoTracking()
            .Where(m => m.Name.Contains(termo!) || m.Description.Contains(termo!))
            .ToArrayAsync();
        
        PrintHelpers.PrintHeader("Materiais");

        foreach (var material in materials)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"ID: {material.Id} | Name: {material.Name}, Price Per Unit: {material.PricePerUnit} - {material.Description}");
            Console.WriteLine($"Atualizado em: {material.UpdatedAt}\n");
            Console.ResetColor();
        }
        
        PrintHelpers.PrintFooter();
    }
}