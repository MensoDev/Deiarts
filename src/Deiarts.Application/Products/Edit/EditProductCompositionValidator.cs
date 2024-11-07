namespace Deiarts.Application.Products.Edit;

public class EditProductCompositionValidator : AbstractValidator<EditProductCompositionDto>
{
    public EditProductCompositionValidator()
    {
        RuleFor(dto => dto.Description).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(dto => dto.Quantity).GreaterThan(0);
        RuleFor(dto => dto.RawMaterialId).NotNull();
    }
}