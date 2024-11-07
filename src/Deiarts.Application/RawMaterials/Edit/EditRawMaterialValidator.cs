namespace Deiarts.Application.RawMaterials.Edit;

public class EditRawMaterialValidator : AbstractValidator<EditRawMaterialRequest>
{
    public EditRawMaterialValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);
        
        RuleFor(request => request.Description)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(500);

        RuleFor(request => request.UnitOfMeasure)
            .NotEmpty()
            .IsInEnum();
        
        RuleFor(request => request.CostPerUnit)
            .NotEmpty()
            .PrecisionScale(18, 2, false)
            .GreaterThan(0);
    }
}