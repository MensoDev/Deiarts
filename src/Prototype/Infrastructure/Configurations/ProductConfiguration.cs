using Deiarts.Prototype.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deiarts.Prototype.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        builder.Property(x => x.LaborTime).IsRequired();

        builder
            .HasMany(x => x.Materials)
            .WithMany(material => material.Products)
            .UsingEntity<ProductMaterial>(options =>
            {
                options.Property(rel => rel.Amount).IsRequired();
            });
    }
}