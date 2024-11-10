namespace Deiarts.Application.Quotations.List;

public class ListQuotationsEndpoint() : QueryEndpoint<ListQuotationsResponseItem[]>(
    Default.ListQuotationsResponseItemArray,
    allowAnonymous: true)
{
    internal static async Task<ListQuotationsResponseItem[]> ExecuteAsync(IQuotationQueries queries)
    {
        return await queries.ListAsync();
    }
}