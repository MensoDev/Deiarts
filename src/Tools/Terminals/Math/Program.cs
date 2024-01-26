using Deiarts.Tools.Terminals.MathBudget.Commands.Budgets;
using Deiarts.Tools.Terminals.MathBudget.Commands.Materials;
using Deiarts.Tools.Terminals.MathBudget.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var builder = CoconaApp.CreateBuilder();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MathBudgetDbContext>(options => { options.UseSqlite(connectionString); });

var app = builder.Build();


app.AddSubCommand("materiais", commandsBuilder => { commandsBuilder.AddCommands<MaterialCommands>(); });
app.AddSubCommand("orcamentos", commandsBuilder => { commandsBuilder.AddCommands<BudgetCommands>(); });


await app.RunAsync();