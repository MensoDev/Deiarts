using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deiarts.Prototype.Infrastructure.Configurations;

internal sealed class BatchConfiguration : IEntityTypeConfiguration<Batch>
{
    public void Configure(EntityTypeBuilder<Batch> builder)
    {
        builder.ToTable("Batches", "dbo");
        
        builder.HasKey(batch => batch.Id);
        
        builder
            .Property(feedstock => feedstock.Quantity)
            .IsRequired()
            .HasPrecision(18, 6);
        
        builder
            .Property(feedstock => feedstock.ConsumedQuantity)
            .IsRequired()
            .HasPrecision(18, 6);
        
        builder
            .Property(feedstock => feedstock.PricePerUnit)
            .IsRequired()
            .HasPrecision(18, 6);

        builder
            .HasOne(batch => batch.Feedstock)
            .WithMany(feedstock => feedstock.Batches)
            .HasForeignKey(batch => batch.FeedStockId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}