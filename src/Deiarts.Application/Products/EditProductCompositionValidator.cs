namespace Deiarts.Application.Products;

public class ProductCompositionValidator : AbstractValidator<ProductCompositionModel>
{
    public ProductCompositionValidator()
    {
        RuleFor(dto => dto.Description).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(dto => dto.Quantity).GreaterThan(0);
        RuleFor(dto => dto.RawMaterialId).NotNull();
    }
}