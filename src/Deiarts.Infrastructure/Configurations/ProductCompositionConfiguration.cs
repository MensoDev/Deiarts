using Deiarts.Domain.Products;
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Infrastructure.Configurations;

internal class ProductCompositionConfiguration : IEntityTypeConfiguration<ProductComposition>
{
    public void Configure(EntityTypeBuilder<ProductComposition> builder)
    {
        // Table
        
        builder.HasKey(composition => composition.Id);
        builder.Property(composition => composition.Id).ValueGeneratedOnAdd();
        
        // Properties
        
        builder.Property(composition => composition.Description).IsRequired().HasMaxLength(500);
        builder.Property(composition => composition.Quantity).IsRequired();
        
        // FKs
        
        builder.Property(composition => composition.ProductId).IsRequired();
        builder.Property(composition => composition.RawMaterialId).IsRequired();
        
        // Relationships
        
        builder
            .HasOne<Product>()
            .WithMany(product => product.Compositions)
            .HasForeignKey(composition => composition.ProductId);
        
        builder
            .HasOne<RawMaterial>()
            .WithMany()
            .HasForeignKey(composition => composition.RawMaterialId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}