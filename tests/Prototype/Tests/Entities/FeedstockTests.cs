using Daiarts.Prototype.Domain.Entities;
using Daiarts.Prototype.Domain.Enums;

namespace Daiarts.Prototype.Tests.Entities;

public class FeedstockTests
{
    [Fact]
    public void ShouldReturnErrorWhenNameIsEmpty()
    {
        // Arrange
        var image = new Image("image.png", "image/png", new byte[] { 1, 2, 3 });

        // Act
        var feedstock = new Feedstock("", "Description", UnitOfMeasurement.Kilogram, 1, image);

        // Assert
        feedstock.IsValid.Should().BeFalse();
        feedstock.Notifications.Should().Contain(notification => notification.Key == nameof(feedstock.Name));
        feedstock.Notifications.Should().Contain(notification => notification.Message == "Name is required");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenDescriptionIsEmpty()
    {
        // Arrange
        var image = new Image("image.png", "image/png", new byte[] { 1, 2, 3 });

        // Act
        var feedstock = new Feedstock("Name", "", UnitOfMeasurement.Kilogram, 1, image);

        // Assert
        feedstock.IsValid.Should().BeFalse();
        feedstock.Notifications.Should().Contain(notification => notification.Key == nameof(feedstock.Description));
        feedstock.Notifications.Should().Contain(notification => notification.Message == "Description is required");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenQuantityIsLessThanZero()
    {
        // Arrange
        var image = new Image("image.png", "image/png", new byte[] { 1, 2, 3 });

        // Act
        var feedstock = new Feedstock("Name", "Description", UnitOfMeasurement.Kilogram, -1, image);

        // Assert
        feedstock.IsValid.Should().BeFalse();
        feedstock.Notifications.Should().Contain(notification => notification.Key == nameof(feedstock.Quantity));
        feedstock.Notifications.Should().Contain(notification => notification.Message == "Quantity must be greater than 0");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenImageIsInvalid()
    {
        // Arrange
        var image = new Image("", "", Array.Empty<byte>());

        // Act
        var feedstock = new Feedstock("Name", "Description", UnitOfMeasurement.Kilogram, 1, image);

        // Assert
        feedstock.IsValid.Should().BeFalse();
        
        feedstock.Notifications.Should().Contain(notification => notification.Key == nameof(image.Name));
        feedstock.Notifications.Should().Contain(notification => notification.Message == "Image name is required");
        
        feedstock.Notifications.Should().Contain(notification => notification.Key == nameof(image.ContentType));
        feedstock.Notifications.Should().Contain(notification => notification.Message == "Image content type is required");
        
        feedstock.Notifications.Should().Contain(notification => notification.Key == nameof(image.Content));
        feedstock.Notifications.Should().Contain(notification => notification.Message == "Image content is required");
    }
    
    [Fact]
    public void ShouldReturnSuccessWhenImageIsValid()
    {
        // Arrange
        var image = new Image("Image Name", "image/png", new byte[] { 1, 2, 3 });

        // Act
        var feedstock = new Feedstock("Name", "Description", UnitOfMeasurement.Kilogram, 1, image);

        // Assert
        feedstock.IsValid.Should().BeTrue();
    }
}