namespace Deiarts.Prototype.Tests.Domain.ValueObjects;

public class ImageTests
{
    [Fact]
    public void ShouldReturnErrorWhenNameIsEmpty()
    {
        var image = new Image("", "", Array.Empty<byte>());
        image.IsValid.Should().BeFalse();
        image.Notifications.Should().Contain(notification => notification.Key == nameof(Image.Name));
        image.Notifications.Should().Contain(notification => notification.Message == "Image name is required");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenContentIsEmpty()
    {
        var image = new Image("name", "image/png", Array.Empty<byte>());
        image.IsValid.Should().BeFalse();
        image.Notifications.Should().Contain(notification => notification.Key == nameof(Image.Content));
        image.Notifications.Should().Contain(notification => notification.Message == "Image content is required");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenContentTypeIsEmpty()
    {
        var image = new Image("name", "", new byte[] { 1, 2, 3 });
        image.IsValid.Should().BeFalse();
        image.Notifications.Should().Contain(notification => notification.Key == nameof(Image.ContentType));
        image.Notifications.Should().Contain(notification => notification.Message == "Image content type is required");
    }
    
    [Fact]
    public void ShouldReturnSuccessWhenNameAndContentTypeAndContentAreValid()
    {
        var image = new Image("name", "image/png", new byte[] { 1, 2, 3 });
        image.IsValid.Should().BeTrue();
        image.Notifications.Should().BeEmpty();
    }
    
}