using Deiarts.Domain.Quotations;

namespace Deiarts.Application.Quotations.EditeItem;

public class EditQuotationItemEndpoint() : CommandEndpoint<EditQuotationItemRequest>(
    Default.EditQuotationItemRequest,
    validator: new EditQuotationItemValidator(),
    allowAnonymous: true)
{
    internal static async Task ExecuteAsync(
        EditQuotationItemRequest request,
        IQuotationRepository quotationRepository,
        IPricingService pricingService,
        IUnitOfWork unitOfWork)
    {
        var quotation = await quotationRepository.GetAsync(request.Id);
        Throw.When.Null(quotation, "Orçamento não encontrada.");

        var productId = request.ProductId.GetValueOrDefault();
        
        var productPrice = await pricingService.CalculatePriceAsync(productId, request.Quantity);

        if (request.ItemId.HasValue)
        {
            quotation.UpdateItem(request.ItemId.Value, request.Quantity, productPrice, request.Description);
        }
        else
        {
            quotation.AddItem(productId, request.Quantity, productPrice, request.Description);
        }
        
        await unitOfWork.SaveChangesAsync();
    }
}