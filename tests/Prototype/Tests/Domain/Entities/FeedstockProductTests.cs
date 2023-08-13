namespace Deiarts.Prototype.Tests.Domain.Entities;

public class FeedstockProductTests
{
    [Fact]
    public void ShouldReturnErrorWhenFeedstockIdIsEmpty()
    {
        // Arrange
        var feedstockId = Guid.Empty;
        var productId = Guid.NewGuid();
        const UnitOfMeasurement unitOfMeasurement = UnitOfMeasurement.Kilogram;
        const decimal quantity = 1m;

        // Act
        var feedstockProduct = new FeedstockProduct(feedstockId, productId, unitOfMeasurement, quantity);

        // Assert
        feedstockProduct.IsValid.Should().BeFalse();
        feedstockProduct.Notifications.Should().Contain(notification => notification.Key == nameof(feedstockProduct.FeedstockId));
        feedstockProduct.Notifications.Should().Contain(notification => notification.Message == "Feedstock is required");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenProductIdIsEmpty()
    {
        // Arrange
        var feedstockId = Guid.NewGuid();
        var productId = Guid.Empty;
        const UnitOfMeasurement unitOfMeasurement = UnitOfMeasurement.Kilogram;
        const decimal quantity = 1m;

        // Act
        var feedstockProduct = new FeedstockProduct(feedstockId, productId, unitOfMeasurement, quantity);

        // Assert
        feedstockProduct.IsValid.Should().BeFalse();
        feedstockProduct.Notifications.Should().Contain(notification => notification.Key == nameof(feedstockProduct.ProductId));
        feedstockProduct.Notifications.Should().Contain(notification => notification.Message == "Product is required");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenQuantityIsLessThanZero()
    {
        // Arrange
        var feedstockId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        const UnitOfMeasurement unitOfMeasurement = UnitOfMeasurement.Kilogram;
        const decimal quantity = -1m;

        // Act
        var feedstockProduct = new FeedstockProduct(feedstockId, productId, unitOfMeasurement, quantity);

        // Assert
        feedstockProduct.IsValid.Should().BeFalse();
        feedstockProduct.Notifications.Should().Contain(notification => notification.Key == nameof(feedstockProduct.Quantity));
        feedstockProduct.Notifications.Should().Contain(notification => notification.Message == "Quantity must be greater than 0");
    }
    
    [Fact]
    public void ShouldReturnSuccessWhenFeedstockProductIsValid()
    {
        // Arrange
        var feedstockId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        const UnitOfMeasurement unitOfMeasurement = UnitOfMeasurement.Kilogram;
        const decimal quantity = 1m;

        // Act
        var feedstockProduct = new FeedstockProduct(feedstockId, productId, unitOfMeasurement, quantity);

        // Assert
        feedstockProduct.IsValid.Should().BeTrue();
        feedstockProduct.Notifications.Should().BeEmpty();
    }
}