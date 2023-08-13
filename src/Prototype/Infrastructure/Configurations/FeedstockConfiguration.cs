using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deiarts.Prototype.Infrastructure.Configurations;

internal sealed class FeedstockConfiguration : IEntityTypeConfiguration<Feedstock>
{
    public void Configure(EntityTypeBuilder<Feedstock> builder)
    {
        builder
            .HasKey(feedstock => feedstock.Id);

        builder
            .Property(feedstock => feedstock.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(feedstock => feedstock.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(feedstock => feedstock.Quantity)
            .HasPrecision(18, 6);

        builder
            .Property(feedstock => feedstock.UnitOfMeasurement)
            .IsRequired();

        builder
            .OwnsOne(feedstock => feedstock.Image, b =>
            {
                b
                    .Property(image => image.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                b
                    .Property(image => image.ContentType)
                    .IsRequired();
            });
    }
}