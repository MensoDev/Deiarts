using Deiarts.Application.Customers.Get;
using Deiarts.Application.Customers.List;

namespace Deiarts.Application.Customers;

internal interface ICustomerQueries
{
    Task<GetCustomerResponse?> GetAsync(CustomerId id);
    Task<ListCustomersResponseItem[]> ListAsync(string? term);
}