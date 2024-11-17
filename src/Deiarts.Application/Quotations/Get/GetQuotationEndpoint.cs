namespace Deiarts.Application.Quotations.Get;

public class GetQuotationEndpoint() : QueryEndpoint<GetQuotationResponse, ValueRequest<QuotationId>>(
    Default.GetQuotationResponse,
    Default.ValueRequestQuotationId,
    allowAnonymous: true)
{
    internal static async Task<GetQuotationResponse> ExecuteAsync(
        [AsParameters] ValueRequest<QuotationId> request,
        IQuotationQueries queries)
    {
        var response = await queries.GetAsync(request);
        Throw.Http.NotFound.When.Null(response, "Orçamento não encontrado.");
        
        return response;
    }
}