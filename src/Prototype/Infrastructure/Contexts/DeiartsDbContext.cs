using Deiarts.Prototype.Domain.Entities;
using Deiarts.Prototype.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Deiarts.Prototype.Infrastructure.Contexts;

public class DeiartsDbContext : DbContext
{
    public DeiartsDbContext(DbContextOptions<DeiartsDbContext> options) : base(options) { }
    
    public required DbSet<Material> Materials { get; init; }
    public required DbSet<Product> Products { get; init; }
    public required DbSet<Budget> Budgets { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MaterialConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new BudgetConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}