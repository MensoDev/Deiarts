namespace Deiarts.Application.Products.Edit;

public class EditProductValidator : AbstractValidator<EditProductRequest>
{
    public EditProductValidator()
    {
        RuleFor(request => request.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
        RuleFor(request => request.Description).NotEmpty().MinimumLength(10).MaximumLength(500);

        RuleFor(request => request.Compositions)
            .NotEmpty()
            .WithMessage("Deve ser informado ao menos uma composição.");
        
        RuleForEach(request => request.Compositions)
            .SetValidator(new EditProductCompositionValidator());
    }
}