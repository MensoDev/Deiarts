using Deiarts.Tools.Terminals.MathBudget.Commands.Budgets.Parameters;
using Deiarts.Tools.Terminals.MathBudget.Data;
using Deiarts.Tools.Terminals.MathBudget.Entities;
using Microsoft.EntityFrameworkCore;

namespace Deiarts.Tools.Terminals.MathBudget.Commands.Budgets;

public class BudgetCommands
{
    [Command("novo", Description = "Cria um orçamento/produto")]
    public async Task Create(CreateBudgetParameters parameters, [FromService] MathBudgetDbContext context)
    {
        var budget = new Budget(parameters.Client, parameters.Product, parameters.TimeServiceInMinutes);
        context.Budgets.Add(budget);
        
        await context.SaveChangesAsync();
        
        Alert.WriteSuccess($"Orçamento '{budget.Product}' criado com sucesso!");
    }
    
    [Command("adicionar-material", Description = "Adiciona um material a um orçamento/produto")]
    public async Task AddMaterial(AddMaterialParameters parameters, [FromService] MathBudgetDbContext context)
    {
        var budget = await context
            .Budgets
            .Include(x => x.Materials)
            .FirstOrDefaultAsync(x => x.Id == parameters.BudgetId);
        
        if (budget is null)
        {
            Alert.WriteError("Orçamento não encontrado!");
            return;
        }
        
        var material = await context
            .Materials
            .FirstOrDefaultAsync(x => x.Id == parameters.MaterialId);
        
        if (material is null)
        {
            Alert.WriteError("Material não encontrado!");
            return;
        }
        
        budget.AddMaterial(material, parameters.Amount);
        
        await context.SaveChangesAsync();
        
        Alert.WriteSuccess($"Material '{material.Name}' adicionado ao orçamento '{budget.Product}' com sucesso!");
    }
    
    [Command("remover-material", Description = "Remove um material de um orçamento/produto")]
    public async Task RemoveMaterial(RemoveMaterialParameters parameters, [FromService] MathBudgetDbContext context)
    {
        var budget = await context
            .Budgets
            .Include(x => x.Materials)
            .FirstOrDefaultAsync(x => x.Id == parameters.BudgetId);
        
        if (budget is null)
        {
            Alert.WriteError("Orçamento não encontrado!");
            return;
        }
        
        var material = await context
            .Materials
            .FirstOrDefaultAsync(x => x.Id == parameters.MaterialId);
        
        if (material is null)
        {
            Alert.WriteError("Material não encontrado!");
            return;
        }
        
        budget.RemoveMaterial(material);
        
        await context.SaveChangesAsync();
        
        Alert.WriteSuccess($"Material '{material.Name}' removido do orçamento '{budget.Product}' com sucesso!");
    }
    
    [Command("listar", Description = "Listar todos os orçamentos/produtos")]
    public async Task ListAll([FromService] MathBudgetDbContext context, [Option] string? termo = "")
    {
        var budgets = await context
            .Budgets
            .AsNoTracking()
            .Where(m => m.Client.Contains(termo!) || m.Product.Contains(termo!))
            .ToArrayAsync();
        
        Printer.PrintHeader("Orçamentos");
        
        foreach (var budget in budgets)
        {
            PrintShortBudget(budget);
        }
        
        Printer.PrintFooter();
    }
    
    [Command("detalhes", Description = "Mostra os detalhes de um orçamento/produto")]
    public async Task Details([FromService] MathBudgetDbContext context, [Argument(name: "id", Description = "id do orçamento/produto")] int id)
    {
        var budget = await context
            .Budgets
            .AsNoTracking()
            .Include(x => x.Materials)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (budget is null)
        {
            Alert.WriteError("Orçamento não encontrado!");
            return;
        }
        
        Printer.PrintHeader("Detalhes do Orçamento");
        PrintShortBudget(budget);
        
        Printer.WriteDashedLine("Materiais");
        
        foreach (var material in budget.Materials)
        {
            PrintMaterial(material);
        }
        
        Printer.PrintFooter();
    }
    
    [Command("remover", Description = "Remove um orçamento/produto")]
    public async Task Remove([FromService] MathBudgetDbContext context, [Argument(name: "id", Description = "id do orçamento/produto")] int id)
    {
        var budget = await context
            .Budgets
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (budget is null)
        {
            Alert.WriteError("Orçamento não encontrado!");
            return;
        }
        
        var confirm = Printer.Confirm($"Deseja remover o orçamento '{budget.Product}'?");
        
        if (!confirm) return;
        
        context.Budgets.Remove(budget);
        
        await context.SaveChangesAsync();
        
        Alert.WriteSuccess($"Orçamento '{budget.Product}' removido com sucesso!");
    }

    private static void PrintShortBudget(Budget budget)
    {
        Printer.PrintInfo("ID", budget.Id.ToString(), ConsoleColor.Yellow);
        Printer.PrintInfo("Cliente", budget.Client);
        Printer.PrintInfo("Produto", budget.Product, ConsoleColor.Cyan);
        Printer.PrintInfo("Tempo de Serviço", $"{budget.TimeServiceInMinutes} minutos");
        Printer.WriteDashedLine();
        Printer.NewLine();
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