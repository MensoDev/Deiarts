using Deiarts.Domain.Quotations;

namespace Deiarts.Infrastructure.Configurations;

internal class QuotationItemConfiguration : IEntityTypeConfiguration<QuotationItem>
{
    public void Configure(EntityTypeBuilder<QuotationItem> builder)
    {
        // Table
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).ValueGeneratedOnAdd();
        
        // Properties
        builder.Property(item => item.Quantity).IsRequired();
        builder.Property(item => item.Price).HasPrecision(18, 2).IsRequired();
        builder.Property(item => item.PricePerUnit).HasPrecision(18, 2).IsRequired();
        builder.Property(item => item.Description).IsRequired().HasMaxLength(500);
        
        // FKs
        builder.Property(item => item.ProductId).IsRequired();
        builder.Property(item => item.QuotationId).IsRequired();
    }
}