using Deiarts.Tools.Terminals.MathBudget.Data.Configurations;
using Deiarts.Tools.Terminals.MathBudget.Entities;
using Microsoft.EntityFrameworkCore;

namespace Deiarts.Tools.Terminals.MathBudget.Data;

public class MathBudgetDbContext(DbContextOptions<MathBudgetDbContext> options) : DbContext(options)
{
    public required DbSet<Material> Materials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MaterialConfiguration());
    }
}