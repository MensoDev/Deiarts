using Deiarts.Application.Quotations;
using Deiarts.Application.Quotations.List;

namespace Deiarts.Infrastructure.Queries;

internal class QuotationQueries(DeiartsDbContext db) : IQuotationQueries
{
    public Task<ListQuotationsResponseItem[]> ListAsync()
    {
        var query = from quotation in db.Quotations
            join customer in db.Customers on quotation.CustomerId equals customer.Id
            select new ListQuotationsResponseItem
            {
                Id = quotation.Id,
                Title = quotation.Title,
                Description = quotation.Description,
                Price = quotation.Price,
                Status = quotation.Status,
                ValidUntil = quotation.ValidUntil,
                CustomerName = customer.Name,
                CustomerEmail = customer.Contact.Email
            };

        return query.ToArrayAsync();
    }
}