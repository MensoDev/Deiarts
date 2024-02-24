using System.Net;
using FluentValidation;

namespace Deiarts.Prototype.Presentation.Web.Extensions;

public static class ValidationFilterExtensions
{
    public static RouteHandlerBuilder AddValidator<TValidator, TRequest>(this RouteHandlerBuilder builder) where TValidator : IValidator<TRequest>, new()
    {
        return builder.AddEndpointFilterFactory((context, next) =>
        {
            var validator = new TValidator();
#if DEBUG
            // Adiciona o validador ao repositório de validadores, para que possa ser consultado pelo Swagger.
            var validatorRepository = context.ApplicationServices.GetRequiredService<ValidatorRepository>();
            validatorRepository.Add(validator);
#endif
            var filter = new ValidationFilter<TValidator, TRequest>(validator);
            return invocationContext => filter.InvokeAsync(invocationContext, next);
        });
    }

    public static RouteHandlerBuilder AddValidatorWhenExist<TValidator, TRequest>(this RouteHandlerBuilder builder) where TValidator : IValidator<TRequest>, new()
    {
        return builder.AddEndpointFilterFactory((context, next) =>
        {
            var parameters = context.MethodInfo.GetParameters();
            var exist = Array.Exists(parameters, param => param.ParameterType == typeof(TRequest));

            if (!exist)
            {
                // pass-thru filter
                return next;
            }

            var validator = new TValidator();
#if DEBUG
            var validatorRepository = context.ApplicationServices.GetRequiredService<ValidatorRepository>();
            validatorRepository.Add(validator);
#endif
            var filter = new ValidationFilter<TValidator, TRequest>(validator);
            return invocationContext => filter.InvokeAsync(invocationContext, next);
        });
    }
}

public class ValidationFilter<TValidator, TRequest>(TValidator validator) : IEndpointFilter where TValidator : IValidator<TRequest>, new()
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var argToValidate = context.GetArgument<TRequest>(0);
        if (argToValidate is null)
        {
            return Results.BadRequest($"Request is null or not of type {nameof(TRequest)}");
        }

        var validationResult = await validator.ValidateAsync(argToValidate);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary(), statusCode: (int)HttpStatusCode.UnprocessableEntity);
        }

        // Otherwise invoke the next filter in the pipeline
        return await next.Invoke(context);
    }
}

public class ValidatorRepository
{
    private readonly Dictionary<Type, IValidator> _validators = [];
    public void Add<TValidator>(TValidator validator) where TValidator : IValidator
    {
        if (!_validators.ContainsKey(typeof(TValidator)))
        {
            _validators.Add(typeof(TValidator), validator);
        }
    }   

    public IValidator[] All()
    {
        return _validators.Values.ToArray();
    }
}