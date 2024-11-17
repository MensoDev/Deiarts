namespace Deiarts.Application.Quotations.RemoveItem;

public class RemoveQuotationItemValidator : AbstractValidator<RemoveQuotationItemRequest>
{
    public RemoveQuotationItemValidator()
    {
        RuleFor(request => request.Id).IsValidRequiredId();
        RuleFor(request => request.ItemId).IsValidRequiredId();
    }
}