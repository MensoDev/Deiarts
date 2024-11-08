namespace Deiarts.Application.Customers.Edit;

public class EditCustomerValidator : AbstractValidator<EditCustomerRequest>
{
    public EditCustomerValidator()
    {
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.Phone).NotEmpty();
        RuleFor(request => request.Email).NotEmpty().EmailAddress();
    }
}