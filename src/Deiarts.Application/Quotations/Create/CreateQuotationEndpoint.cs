using Deiarts.Domain.Quotations;

namespace Deiarts.Application.Quotations.Create;

public class CreateQuotationEndpoint() : CommandEndpoint<CreateQuotationResponse, CreateQuotationRequest>(
    Default.CreateQuotationResponse,
    Default.CreateQuotationRequest,
    new CreateQuotationValidator(),
    allowAnonymous: true)
{
    internal static async Task<CreateQuotationResponse> ExecuteAsync(CreateQuotationRequest request, IQuotationRepository repository, IUnitOfWork unitOfWork)
    {
        var quotation = new Quotation(request.CustomerId.GetValueOrDefault(), request.Title, request.Description);
        repository.Add(quotation);
        
        await unitOfWork.SaveChangesAsync();
        return new CreateQuotationResponse { Id = quotation.Id };
    }
}