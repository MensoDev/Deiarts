namespace Daiarts.Prototype.Domain.ValueObjects;

public class Image : ValueObject
{
    public Image(string name, string contentType, byte[] content)
    {
        Name = name;
        ContentType = contentType;
        Content = content;

        AddNotifications(DomainNotifications
            .Rules
            .Requires()
            .IsNotNullOrEmpty(Name, nameof(Name), "Image name is required")
            .IsNotNullOrEmpty(ContentType, nameof(ContentType), "Image content type is required")
            .IsNotEmpty(Content, nameof(Content), "Image content is required")
        );
    }

    public string Name { get; private set; }
    public string ContentType { get; private set; }
    public byte[] Content { get; private set; }
}