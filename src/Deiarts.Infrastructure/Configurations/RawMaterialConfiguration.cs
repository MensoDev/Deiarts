using Deiarts.Domain.RawMaterials;

namespace Deiarts.Infrastructure.Configurations;

internal class RawMaterialConfiguration : IEntityTypeConfiguration<RawMaterial>
{
    public void Configure(EntityTypeBuilder<RawMaterial> builder)
    {
        builder.HasKey(rawMaterial => rawMaterial.Id);

        builder.Property(rawMaterial => rawMaterial.Id).ValueGeneratedOnAdd();
        builder.Property(rawMaterial => rawMaterial.Name).HasMaxLength(100).IsRequired();
        builder.Property(rawMaterial => rawMaterial.Description).HasMaxLength(500).IsRequired();
    }
}