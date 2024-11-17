namespace Deiarts.Application.Quotations.EditeItem;

public class EditQuotationItemValidator : AbstractValidator<EditQuotationItemRequest>
{
    public EditQuotationItemValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
        
        RuleFor(request => request.Quantity).NotEmpty().GreaterThan(0);
        RuleFor(request => request.ProductId).NotEmpty();
        RuleFor(request => request.Description).NotEmpty().MaximumLength(500);
    }
}