using Deiarts.Application.Customers;
using Deiarts.Application.Customers.Get;
using Deiarts.Application.Customers.List;

namespace Deiarts.Infrastructure.Queries;

internal class CustomerQueries(DeiartsDbContext db) : ICustomerQueries
{
    public async Task<GetCustomerResponse?> GetAsync(CustomerId id)
    {
        return await db
            .Customers
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Select(c => new GetCustomerResponse
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Contact.Email,
                Phone = c.Contact.Phone
            })
            .SingleOrDefaultAsync();
    }

    public async Task<ListCustomersResponseItem[]> ListAsync(string? term)
    {
        var query = db
            .Customers
            .AsNoTracking();

        if (term.IsNotNullOrWhiteSpace())
        {
            query = query.Where(c => c.Name.Contains(term));
        }

        return await query.Select(c => new ListCustomersResponseItem
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Contact.Email,
                Phone = c.Contact.Phone
            })
            .ToArrayAsync();
    }
}