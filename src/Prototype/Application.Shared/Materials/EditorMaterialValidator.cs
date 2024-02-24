using FluentValidation;

namespace Deiarts.Prototype.Application.Shared.Materials;

public class EditorMaterialValidator : AbstractValidator<EditorMaterialRequest>
{
    public EditorMaterialValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage("Nome é obrigatório.");
        RuleFor(request => request.Description).NotEmpty().WithMessage("Descrição é obrigatória.");
        RuleFor(request => request.PricePerUnit)
            .NotEmpty()
            .WithMessage("Preço por unidade é obrigatório.")
            .GreaterThan(0)
            .WithMessage("Preço por unidade deve ser maior que 0.");
    }
}