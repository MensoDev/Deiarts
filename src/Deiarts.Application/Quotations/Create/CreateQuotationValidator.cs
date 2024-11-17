namespace Deiarts.Application.Quotations.Create;

public class CreateQuotationValidator : AbstractValidator<CreateQuotationRequest>
{
    public CreateQuotationValidator()
    {
        RuleFor(request => request.Title).NotEmpty().MaximumLength(100);
        RuleFor(request => request.Description).NotEmpty().MaximumLength(500);
        RuleFor(request => request.CustomerId).NotNull();
    }
}