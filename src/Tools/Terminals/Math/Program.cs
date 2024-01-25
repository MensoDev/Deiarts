using Cocona;
using Deiarts.Tools.Terminals.MathBudget.Commands.Materials;
using Deiarts.Tools.Terminals.MathBudget.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var builder = CoconaApp.CreateBuilder();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MathBudgetDbContext>(options => { options.UseSqlite(connectionString); });

var app = builder.Build();


app.AddSubCommand("materiais", (commandsBuilder) =>
{

    commandsBuilder.AddCommands<MaterialCommands>();

});


// app.AddSubCommand("budget", (options) =>
// {
//
//     options.AddCommand("new", () =>
//     {
//         Console.WriteLine("New budget in progress...");
//     });
//     
//     options.AddCommand("edit", () =>
//     {
//         Console.WriteLine("Edit budget in progress...");
//     });
//     
//     options.AddCommand("delete", () =>
//     {
//         Console.WriteLine("Delete budget in progress...");
//     });
//     
//     options.AddCommand("list", () =>
//     {
//         Console.WriteLine("List budget in progress...");
//     });
//     
//     options.AddCommand("show", ([Argument(name: "Id or Code", Description = "identificador do orçamento")] string idOrCode) =>
//     {
//         Console.WriteLine("Show budget in progress...");
//     });
//
// });

await app.RunAsync();