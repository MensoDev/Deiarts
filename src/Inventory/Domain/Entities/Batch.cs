namespace Daiarts.Inventory.Domain.Entities;

public class Batch : Entity
{
    public Batch(Guid feedStockId, decimal quantity, decimal consumedQuantity, UnitOfMeasurement unitOfMeasurement, BatchStatus status)
    {
        FeedStockId = feedStockId;
        Quantity = quantity;
        ConsumedQuantity = consumedQuantity;
        UnitOfMeasurement = unitOfMeasurement;
        Status = status;
    }

    public Guid FeedStockId { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal ConsumedQuantity { get; private set; }
    public UnitOfMeasurement UnitOfMeasurement { get; private set; }
    public BatchStatus Status { get; private set; }
    
}