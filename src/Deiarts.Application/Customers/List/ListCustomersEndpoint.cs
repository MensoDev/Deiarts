namespace Deiarts.Application.Customers.List;

public class ListCustomersEndpoint() : QueryEndpoint<ListCustomersResponseItem[], ListCustomersRequest>(
    Default.ListCustomersResponseItemArray,
    Default.ListCustomersRequest,
    allowAnonymous: true)
{
    internal static async Task<ListCustomersResponseItem[]> ExecuteAsync(
        [AsParameters] ListCustomersRequest request,
        ICustomerQueries queries)
    {
        return await queries.ListAsync(request.Term);
    }
}