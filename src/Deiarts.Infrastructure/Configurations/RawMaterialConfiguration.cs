using Deiarts.Domain.RawMaterials;

namespace Deiarts.Infrastructure.Configurations;

internal class RawMaterialConfiguration : IEntityTypeConfiguration<RawMaterial>
{
    public void Configure(EntityTypeBuilder<RawMaterial> builder)
    {
        // Table
        
        builder.HasKey(rawMaterial => rawMaterial.Id);
        builder.Property(rawMaterial => rawMaterial.Id).ValueGeneratedOnAdd();
        
        // Properties
        
        builder.Property(rawMaterial => rawMaterial.Brand).HasMaxLength(100).IsRequired();
        builder.Property(rawMaterial => rawMaterial.CostPerUnit).IsRequired().HasPrecision(18, 2);
        builder.Property(rawMaterial => rawMaterial.Description).HasMaxLength(500).IsRequired();
        builder.Property(rawMaterial => rawMaterial.Name).HasMaxLength(100).IsRequired();
        builder.Property(rawMaterial => rawMaterial.UnitOfMeasure).IsRequired();
    }
}