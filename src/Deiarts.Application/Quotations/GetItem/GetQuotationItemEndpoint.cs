namespace Deiarts.Application.Quotations.GetItem;

public class GetQuotationItemEndpoint() : QueryEndpoint<GetQuotationItemResponse, ValueRequest<QuotationItemId>>(
    Default.GetQuotationItemResponse,
    Default.ValueRequestQuotationItemId,
    allowAnonymous: true)
{
    internal static async Task<GetQuotationItemResponse> ExecuteAsync(
        [AsParameters] ValueRequest<QuotationItemId> request,
        IQuotationQueries queries)
    {
        var quotationItem = await queries.GetItemAsync(request);
        Throw.When.Null(quotationItem, "Item de orçamento não encontrado.");
        
        return quotationItem;
    }
}