

using Deiarts.Domain.Quotations;

namespace Deiarts.Application.Quotations.RemoveItem;

public class RemoveQuotationItemEndpoint() : CommandEndpoint<RemoveQuotationItemRequest>(
    Default.RemoveQuotationItemRequest,
    validator: new RemoveQuotationItemValidator(),
    allowAnonymous: true)
{
    internal static async Task ExecuteAsync(
        RemoveQuotationItemRequest request, 
        IQuotationRepository quotationRepository, 
        IUnitOfWork unitOfWork)
    {
        var quotation = await quotationRepository.GetAsync(request.Id);
        Throw.When.Null(quotation, "Orçamento não encontrada.");
        
        quotation.RemoveItem(request.ItemId);
        
        await unitOfWork.SaveChangesAsync();
    }
}