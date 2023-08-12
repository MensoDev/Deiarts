using Daiarts.Prototype.Domain.Enums;

namespace Daiarts.Prototype.Domain.Entities;

public sealed class FeedstockProduct : Entity
{
    public FeedstockProduct(Guid feedstockId, Guid productId, UnitOfMeasurement unitOfMeasurement, decimal quantity)
    {
        FeedstockId = feedstockId;
        ProductId = productId;
        UnitOfMeasurement = unitOfMeasurement;
        Quantity = quantity;
        
        AddNotifications(DomainNotifications
            .Rules
            .Requires()
            .IsNotEmpty(FeedstockId, nameof(FeedstockId), "Feedstock is required")
            .IsNotEmpty(ProductId, nameof(ProductId), "Product is required")
            .IsGreaterThan(Quantity, 0, nameof(Quantity), "Quantity must be greater than 0")
        );
    }

    public Guid FeedstockId { get; private set; }
    public Guid ProductId { get; private set; }
    public UnitOfMeasurement UnitOfMeasurement { get; private set; }
    public decimal Quantity { get; private set; }
}