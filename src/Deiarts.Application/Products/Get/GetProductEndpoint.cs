namespace Deiarts.Application.Products.Get;

public class GetProductEndpoint() : QueryEndpoint<GetProductResponse, ValueRequest<ProductId>>(
    Default.GetProductResponse,
    Default.ValueRequestProductId,
    allowAnonymous: true)
{
    internal static async Task<GetProductResponse> ExecuteAsync(
        [AsParameters] ValueRequest<ProductId> request,
        IProductQueries queries)
    {
        var product = await queries.GetAsync(request);
        Throw.Http.NotFound.When.Null(product, "Produto não encontrado.");
        return product;
    }
}