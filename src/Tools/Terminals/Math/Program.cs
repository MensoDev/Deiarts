using Deiarts.Tools.Terminals.MathBudget.Commands.Budgets;
using Deiarts.Tools.Terminals.MathBudget.Commands.Materials;
using Deiarts.Tools.Terminals.MathBudget.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;


var builder = CoconaApp.CreateBuilder();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MathBudgetDbContext>(options => { options.UseSqlite(connectionString); });

var app = builder.Build();


app.AddSubCommand("materiais", commandsBuilder => { commandsBuilder.AddCommands<MaterialCommands>(); });
app.AddSubCommand("orcamentos", commandsBuilder => { commandsBuilder.AddCommands<BudgetCommands>(); });

// aciona o previewer quando usado o comando docx
app.AddCommand("docx", async () =>
{
    await Document.Create(GenerateDocument).ShowInPreviewerAsync();
});


await app.RunAsync();


// pode ficar em uma class internal separada
static void GenerateDocument(IDocumentContainer document)
{
    // Cria os dados fakes para testes
    var data = new Data();
    
    // Gera o documento, e esse código seria reaproveitado para gerar o PDF no service
    GenerateDocumentX(document, data);
}

// pode ficar em uma class separada que seria chamada pelo service
static void GenerateDocumentX(IDocumentContainer document, Data data)
{
    // Regras para gerar o documento
}

record Data();