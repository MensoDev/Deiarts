using Deiarts.Application.Quotations.Get;
using Deiarts.Application.Quotations.GetItem;
using Deiarts.Application.Quotations.List;

namespace Deiarts.Application.Quotations;

internal interface IQuotationQueries
{
    Task<ListQuotationsResponseItem[]> ListAsync();
    Task<GetQuotationResponse?> GetAsync(QuotationId id);
    Task<GetQuotationItemResponse?> GetItemAsync(QuotationItemId id);
}