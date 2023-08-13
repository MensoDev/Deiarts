using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deiarts.Prototype.Infrastructure.Configurations;

internal sealed class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.HasKey(budget => budget.Id);
        
        builder
            .Property(budget => budget.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(budget => budget.Description)
            .HasMaxLength(200)
            .IsRequired();
        
        builder
            .Property(budget => budget.Status)
            .IsRequired();
        
        builder
            .Property(budget => budget.Validity)
            .IsRequired();
    }
}