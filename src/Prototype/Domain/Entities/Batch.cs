using Deiarts.Prototype.Domain.Enums;

namespace Deiarts.Prototype.Domain.Entities;

public class Batch : Entity
{
    public Batch(Guid feedStockId, decimal quantity, decimal consumedQuantity, UnitOfMeasurement unitOfMeasurement, BatchStatus status, decimal pricePerUnit)
    {
        FeedStockId = feedStockId;
        Quantity = quantity;
        ConsumedQuantity = consumedQuantity;
        UnitOfMeasurement = unitOfMeasurement;
        Status = status;
        PricePerUnit = pricePerUnit;
    }

    public decimal Quantity { get; private set; }
    public decimal ConsumedQuantity { get; private set; }
    public decimal PricePerUnit { get; private set; }
    public UnitOfMeasurement UnitOfMeasurement { get; private set; }
    public BatchStatus Status { get; private set; }
    public Guid FeedStockId { get; private set; }
}