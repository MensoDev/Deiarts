using Deiarts.Prototype.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deiarts.Prototype.Infrastructure.Configurations;

public class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable("Materials");
        
        builder.HasKey(material => material.Id);
        builder.Property(material => material.Id).ValueGeneratedOnAdd();
        
        builder.Property(material => material.Name).IsRequired().HasMaxLength(150);
        builder.Property(material => material.PricePerUnit).IsRequired().HasPrecision(18, 2);
        builder.Property(material => material.Description).IsRequired().HasMaxLength(350);
    }
}