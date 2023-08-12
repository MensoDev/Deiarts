using Daiarts.Prototype.Domain.Enums;

namespace Daiarts.Prototype.Domain.Entities;

public sealed class FeedstockProduct
{
    public FeedstockProduct(Guid feedstockId, Guid productId, UnitOfMeasurement unitOfMeasurement, decimal quantity)
    {
        FeedstockId = feedstockId;
        ProductId = productId;
        UnitOfMeasurement = unitOfMeasurement;
        Quantity = quantity;
    }

    public Guid FeedstockId { get; private set; }
    public Guid ProductId { get; private set; }
    public UnitOfMeasurement UnitOfMeasurement { get; private set; }
    public decimal Quantity { get; private set; }
}