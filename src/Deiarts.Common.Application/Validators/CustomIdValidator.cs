using FluentValidation.Validators;

namespace Deiarts.Common.Application.Validators;

internal class CustomIdValidator<TEntity, TProperty>(bool allowNullValue) : PropertyValidator<TEntity, TProperty>
{

    private string? _errorMessage;
    

    public override string Name => "CustomIdValidator";
    
    public override bool IsValid(ValidationContext<TEntity> context, TProperty value)
    {
        if (allowNullValue && value is null)
        {
            _errorMessage = null;
            return true;
        }

        if (value is null)
        {
            _errorMessage = "'{PropertyName}' é obrigatório!";
            return false;
        }
        
        var stringValue = value.ToString()!;

        if (!stringValue.Equals(Guid.Empty.ToString())) return true;
        
        _errorMessage = "'{PropertyName}' é inválido";
        return false;
    }

    

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return _errorMessage ?? base.GetDefaultMessageTemplate(errorCode);
    }
}