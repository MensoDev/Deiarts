using Deiarts.Tools.Terminals.MathBudget.Data.Configurations;
using Deiarts.Tools.Terminals.MathBudget.Entities;
using Microsoft.EntityFrameworkCore;

namespace Deiarts.Tools.Terminals.MathBudget.Data;

public class MathBudgetDbContext(DbContextOptions<MathBudgetDbContext> options) : DbContext(options)
{
    public required DbSet<Material> Materials { get; init; }
    public required DbSet<Budget> Budgets { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MaterialConfiguration());
        modelBuilder.ApplyConfiguration(new BudgetConfiguration());
    }
}