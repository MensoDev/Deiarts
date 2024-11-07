using Deiarts.Domain.Products;

namespace Deiarts.Application.Products.List;

public class ListProductsResponseItem
{
    public required ProductId Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int CompositionsCount { get; set; }
}