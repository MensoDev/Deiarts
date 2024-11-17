using Deiarts.Application.Products.Get;
using Deiarts.Application.Products.List;
using Deiarts.Domain.Products;

namespace Deiarts.Application.Products;

internal interface IProductQueries
{
    Task<ListProductsResponseItem[]> ListAsync(string? term);

    Task<GetProductResponse?> GetAsync(ProductId productId);
}