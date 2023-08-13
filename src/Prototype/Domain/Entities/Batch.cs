using Deiarts.Prototype.Domain.Enums;

namespace Deiarts.Prototype.Domain.Entities;

public sealed class Batch : Entity
{
    public Batch(Guid feedStockId, decimal quantity, decimal consumedQuantity, UnitOfMeasurement unitOfMeasurement, BatchStatus status, decimal pricePerUnit)
    {
        FeedStockId = feedStockId;
        Quantity = quantity;
        ConsumedQuantity = consumedQuantity;
        UnitOfMeasurement = unitOfMeasurement;
        Status = status;
        PricePerUnit = pricePerUnit;

        AddNotifications(DomainNotifications
            .Rules
            .IsGreaterThan(Quantity, 0, nameof(Quantity), "The quantity must be greater than zero")
            .IsGreaterThan(ConsumedQuantity, 0, nameof(ConsumedQuantity), "The consumed quantity must be greater than zero")
            .IsGreaterThan(PricePerUnit, 0, nameof(PricePerUnit), "The price per unit must be greater than zero")
            .IsNotEmpty(FeedStockId, nameof(FeedStockId), "The feed stock id must be informed")
        );
    }

    public decimal Quantity { get; private set; }
    public decimal ConsumedQuantity { get; private set; }
    public decimal PricePerUnit { get; private set; }
    public UnitOfMeasurement UnitOfMeasurement { get; private set; }
    public BatchStatus Status { get; private set; }
    public Guid FeedStockId { get; private set; }
}