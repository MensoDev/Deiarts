using Deiarts.Domain.Products;

namespace Deiarts.Infrastructure.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Table
        
        builder.HasKey(product => product.Id);
        builder.Property(product => product.Id).ValueGeneratedOnAdd();
        
        // Properties
        
        builder.Property(product => product.Name).IsRequired().HasMaxLength(100);
        builder.Property(product => product.Description).IsRequired().HasMaxLength(500);
        
        // Relationships
        
        builder
            .HasMany(product => product.Compositions)
            .WithOne()
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(product => product.Compositions).AutoInclude();
    }
}