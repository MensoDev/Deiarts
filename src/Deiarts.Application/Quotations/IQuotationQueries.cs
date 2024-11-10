using Deiarts.Application.Quotations.List;

namespace Deiarts.Application.Quotations;

internal interface IQuotationQueries
{
    Task<ListQuotationsResponseItem[]> ListAsync();
}