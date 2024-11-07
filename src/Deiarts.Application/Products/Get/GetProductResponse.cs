using Deiarts.Domain.Products;

namespace Deiarts.Application.Products.Get;

public class GetProductResponse
{
    public required ProductId Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required ProductCompositionModel[] Compositions { get; set; }
}