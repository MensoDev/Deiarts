namespace Deiarts.Application.Customers.Get;

public class GetCustomerEndpoint() : QueryEndpoint<GetCustomerResponse, ValueRequest<CustomerId>>(
    Default.GetCustomerResponse,
    Default.ValueRequestCustomerId,
    allowAnonymous: true)
{
    internal static async Task<GetCustomerResponse> ExecuteAsync(
        [AsParameters] ValueRequest<CustomerId> request,
        ICustomerQueries queries)
    {
        var customer = await queries.GetAsync(request);
        Throw.Http.NotFound.When.Null(customer, "Cliente não encontrado.");
        return customer;
    }
}