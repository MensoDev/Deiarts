namespace Deiarts.Application.Products.List;

public class ListProductsEndpoint() : QueryEndpoint<ListProductsResponseItem[], ListProductsRequest>(
    Default.ListProductsResponseItemArray,
    Default.ListProductsRequest,
    allowAnonymous: true)
{
    internal static async Task<ListProductsResponseItem[]> ExecuteAsync(
        [AsParameters] ListProductsRequest request,
        IProductQueries queries)
    {
        return await queries.ListAsync(request.Term);
    }
}