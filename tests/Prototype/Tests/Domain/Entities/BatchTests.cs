namespace Deiarts.Prototype.Tests.Domain.Entities;

public class BatchTests
{
    [Fact]
    public void ShouldReturnErrorWhenQuantityIsLessThanZero()
    {
        // Arrange
        var feedStockId = Guid.NewGuid();
        const decimal quantity = -1M;
        const UnitOfMeasurement unitOfMeasurement = UnitOfMeasurement.Kilogram;
        const BatchStatus status = BatchStatus.Available;
        const decimal pricePerUnit = 1M;

        // Act
        var batch = new Batch(feedStockId, quantity, unitOfMeasurement, status, pricePerUnit);

        // Assert
        batch.IsValid.Should().BeFalse();
        batch.Notifications.Should().Contain(notification => notification.Key == nameof(batch.Quantity));
        batch.Notifications.Should().Contain(notification => notification.Message == "The quantity must be greater than zero");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenPricePerUnitIsLessThanZero()
    {
        // Arrange
        var feedStockId = Guid.NewGuid();
        const decimal quantity = 1M;
        const UnitOfMeasurement unitOfMeasurement = UnitOfMeasurement.Kilogram;
        const BatchStatus status = BatchStatus.Available;
        const decimal pricePerUnit = -1M;

        // Act
        var batch = new Batch(feedStockId, quantity, unitOfMeasurement, status, pricePerUnit);

        // Assert
        batch.IsValid.Should().BeFalse();
        batch.Notifications.Should().Contain(notification => notification.Key == nameof(batch.PricePerUnit));
        batch.Notifications.Should().Contain(notification => notification.Message == "The price per unit must be greater than zero");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenFeedStockIdIsEmpty()
    {
        // Arrange
        var feedStockId = Guid.Empty;
        const decimal quantity = 1M;
        const UnitOfMeasurement unitOfMeasurement = UnitOfMeasurement.Kilogram;
        const BatchStatus status = BatchStatus.Available;
        const decimal pricePerUnit = 1M;

        // Act
        var batch = new Batch(feedStockId, quantity, unitOfMeasurement, status, pricePerUnit);

        // Assert
        batch.IsValid.Should().BeFalse();
        batch.Notifications.Should().Contain(notification => notification.Key == nameof(batch.FeedStockId));
        batch.Notifications.Should().Contain(notification => notification.Message == "The feed stock id must be informed");
    }
    
    [Fact]
    public void ShouldReturnSuccessWhenCreateBatch()
    {
        // Arrange
        var feedStockId = Guid.NewGuid();
        const decimal quantity = 1M;
        const UnitOfMeasurement unitOfMeasurement = UnitOfMeasurement.Kilogram;
        const BatchStatus status = BatchStatus.Available;
        const decimal pricePerUnit = 1M;

        // Act
        var batch = new Batch(feedStockId, quantity, unitOfMeasurement, status, pricePerUnit);

        // Assert
        batch.IsValid.Should().BeTrue();
    }
}