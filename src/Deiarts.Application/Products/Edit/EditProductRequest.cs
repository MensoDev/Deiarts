using Deiarts.Application.Products.Get;
using Deiarts.Domain.Products;

namespace Deiarts.Application.Products.Edit;

public class EditProductRequest
{
    public ProductId? Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<ProductCompositionModel> Compositions { get; set; } = [];

    public void CopyFrom(GetProductResponse product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Compositions = product.Compositions.ToList();
    }
}