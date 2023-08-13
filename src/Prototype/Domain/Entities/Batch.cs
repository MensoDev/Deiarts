namespace Deiarts.Prototype.Domain.Entities;

public sealed class Batch : Entity
{
    public Batch(Guid feedStockId, decimal quantity, UnitOfMeasurement unitOfMeasurement, BatchStatus status, decimal pricePerUnit)
    {
        FeedStockId = feedStockId;
        Quantity = quantity;
        ConsumedQuantity = 0M;
        UnitOfMeasurement = unitOfMeasurement;
        Status = status;
        PricePerUnit = pricePerUnit;

        AddNotifications(DomainNotifications
            .Rules
            .IsGreaterThan(Quantity, 0, nameof(Quantity), "The quantity must be greater than zero")
            .IsGreaterOrEqualsThan(ConsumedQuantity, 0, nameof(ConsumedQuantity), "The consumed quantity must be greater than or equals to zero")
            .IsGreaterThan(PricePerUnit, 0, nameof(PricePerUnit), "The price per unit must be greater than zero")
            .IsNotEmpty(FeedStockId, nameof(FeedStockId), "The feed stock id must be informed")
        );
    }

    public decimal Quantity { get; private init; }
    public decimal ConsumedQuantity { get; private init; }
    public decimal PricePerUnit { get; private init; }
    public UnitOfMeasurement UnitOfMeasurement { get; private set; }
    public BatchStatus Status { get; private set; }
    
    public Guid FeedStockId { get; private init; }

    public Feedstock Feedstock { get; private set; } = default!;
}