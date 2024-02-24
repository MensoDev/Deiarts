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
        var budget = new Budget(parameters.Product, parameters.TimeServiceInMinutes);
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
            .Where(m => m.Product.Contains(termo!))
            .ToArrayAsync();
        
        Printer.PrintHeader("Orçamentos");
        
        foreach (var budget in budgets)
        {
            PrintShortBudget(budget);
        }
        
        Printer.PrintFooter();
    }
    
    [Command("detalhes", Description = "Mostra os detalhes de um orçamento/produto")]
    public async Task Details(
        [FromService] MathBudgetDbContext context, 
        [Argument(name: "id", Description = "id do orçamento/produto")] int id, 
        [Option("quantidade", [ 'q' ], Description = "Quantidade de items a ser simulado")] int amount = 1)
    {
        var budget = await context
            .Budgets
            .AsNoTracking()
            .Where(b => b.Id == id)
            .Select(b => new BudgetDetails
            {
                Id = b.Id,
                Amount = amount,
                Product = b.Product,
                TimeServiceInMinutes = b.TimeServiceInMinutes,
                Materials = b.BudgetMaterials.Select(bm => new MaterialModel
                {
                    Id = bm.MaterialId,
                    Description = bm.Material.Description,
                    Name = bm.Material.Name,
                    PricePerUnit = bm.Material.PricePerUnit,
                    Amount = bm.Amount
                }).ToArray()
            })
            .FirstOrDefaultAsync();
        
        if (budget is null)
        {
            Alert.WriteError("Orçamento não encontrado!");
            return;
        }
        
        Printer.PrintHeader("Detalhes do Orçamento");
        PrintDetailedBudget(budget);
        
        Printer.WriteDashedLine("Materiais");
        Printer.NewLine();
        
        foreach (var budgetBudget in budget.Materials)
        {
            PrintMaterial(budgetBudget);
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
        Printer.PrintInfo("Produto", budget.Product, ConsoleColor.Cyan);
        Printer.PrintInfo("Tempo de Serviço", $"{budget.TimeServiceInMinutes} minutos");
        Printer.WriteDashedLine();
        Printer.NewLine();
    }
    
    private static void PrintDetailedBudget(BudgetDetails details)
    {
        Printer.PrintInfo("🧾 - ID", details.Id.ToString(), ConsoleColor.Yellow);
        Printer.PrintInfo("📦 - Produto", details.Product, ConsoleColor.Cyan);
        Printer.PrintInfo("⏳ - Tempo de Serviço", $"{details.TimeServiceInMinutes} minutos por item");
        Printer.PrintInfo("📦 - Quantidade", details.Amount.ToString(), ConsoleColor.Yellow);
        
        Printer.SkipLine();
        
        Printer.PrintCurrencyInfo("\u200D - Total do Serviço/Salário", details.TotalService, ConsoleColor.Yellow);
        Printer.PrintCurrencyInfo("🧾 - Total Materiais", details.TotalMaterial, ConsoleColor.Yellow);
        
        Printer.SkipLine();
        
        Printer.PrintCurrencyInfo("📦 - Custo Por Item", details.TotalItem, ConsoleColor.Yellow);
        Printer.PrintCurrencyInfo($"📦 - Custo Por {details.Amount} items", details.Total, ConsoleColor.Yellow);
        
        Printer.SkipLine();
        
        Printer.PrintCurrencyInfo("💵 - Total Mínimo", details.TotalMin, ConsoleColor.Yellow);
        Printer.PrintCurrencyInfo("💵 - Total Máximo", details.TotalMax, ConsoleColor.Yellow);
        Printer.PrintCurrencyInfo("💵 - Total Médio", details.TotalMiddle, ConsoleColor.Yellow);
        
        Printer.SkipLine();
        
        Printer.PrintCurrencyInfo("💲 - Total Mínimo por Item", details.TotalMinPerItem, ConsoleColor.Yellow);
        Printer.PrintCurrencyInfo("💲 - Total Máximo por Item", details.TotalMaxPerItem, ConsoleColor.Yellow);
        Printer.PrintCurrencyInfo("💲 - Total Médio por Item", details.TotalMiddlePerItem, ConsoleColor.Yellow);
        
        Printer.NewLine();
    }

    private static void PrintMaterial(MaterialModel budgetMaterial)
    {
        Printer.PrintInfo("Material ID", budgetMaterial.Id.ToString(), ConsoleColor.Yellow);
        Printer.PrintInfo("Nome", budgetMaterial.Name);
        Printer.PrintCurrencyInfo("Preço por unidade", budgetMaterial.PricePerUnit, ConsoleColor.Yellow);
        Printer.PrintInfo("Descrição", budgetMaterial.Description);
        Printer.PrintInfo("Quantidade", budgetMaterial.Amount.ToString(), ConsoleColor.Yellow);
        Printer.WriteDashedLine();
        Printer.NewLine();
    }
}