using Deiarts.Domain.Quotations;

namespace Deiarts.Infrastructure.Configurations;

internal class QuotationConfiguration : IEntityTypeConfiguration<Quotation>
{
    public void Configure(EntityTypeBuilder<Quotation> builder)
    {
        // Table
        builder.HasKey(quotation => quotation.Id);
        builder.Property(quotation => quotation.Id).ValueGeneratedOnAdd();
        
        // Properties
        builder.Property(quotation => quotation.Title).IsRequired().HasMaxLength(100);
        builder.Property(quotation => quotation.Description).IsRequired().HasMaxLength(500);
        builder.Property(quotation => quotation.Status).IsRequired();
        
        builder.Property(quotation => quotation.Price).HasPrecision(18, 2).IsRequired();
        builder.Property(quotation => quotation.ValidUntil).IsRequired(false);
        
        // FKs
        builder.Property(quotation => quotation.CustomerId).IsRequired();
        
        // Navigation
        builder
            .HasMany(quotation => quotation.Items)
            .WithOne()
            .HasForeignKey(item => item.QuotationId);
        
    }
}