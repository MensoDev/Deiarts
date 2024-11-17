namespace Deiarts.Common.Application.Validators;

public static class ValidatorsExtensions
{
    public static IRuleBuilderOptions<TEntity, TProperty> IsValidRequiredId<TEntity, TProperty>(this IRuleBuilder<TEntity, TProperty> builder)
    {
        return builder.SetValidator(new CustomIdValidator<TEntity, TProperty>(false));
    }
    
    public static IRuleBuilderOptions<TEntity, TProperty> IsValidId<TEntity, TProperty>(this IRuleBuilder<TEntity, TProperty> builder)
    {
        return builder.SetValidator(new CustomIdValidator<TEntity, TProperty>(true));
    }
    
}