using Deiarts.Domain.Products;

namespace Deiarts.Application.Products.Edit;

public class EditProductRequest
{
    public ProductId? Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<EditProductCompositionDto> Compositions { get; set; } = [];
}