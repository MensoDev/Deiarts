using Deiarts.Tools.Terminals.MathBudget.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deiarts.Tools.Terminals.MathBudget.Data.Configurations;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable("Budgets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Client).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Product).HasMaxLength(150).IsRequired();
        builder.Property(x => x.TimeServiceInMinutes).IsRequired();

        builder
            .HasMany(x => x.Materials)
            .WithMany(budget => budget.Budgets)
            .UsingEntity<BudgetMaterial>(options =>
            {
                options.Property(rel => rel.Amount).IsRequired();
            });

    }
}