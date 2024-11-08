namespace Deiarts.Application.Products.List;

public class ListProductsEndpoint() : QueryEndpoint<ListProductsResponseItem[]>(
    Default.ListProductsResponseItemArray,
    allowAnonymous: true)
{
    internal static async Task<ListProductsResponseItem[]> ExecuteAsync(IProductQueries queries)
    {
        return await queries.ListAsync();
    }
}