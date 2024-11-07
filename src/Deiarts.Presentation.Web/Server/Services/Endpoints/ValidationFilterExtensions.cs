using FluentValidation;

namespace Deiarts.Presentation.Web.Services.Endpoints;

public static class ValidationFilterExtensions
{
    public static RouteHandlerBuilder AddValidator<TValidator, TRequest>(this RouteHandlerBuilder builder) where TValidator : IValidator<TRequest>, new()
    {
        return builder.AddEndpointFilter<ValidationFilter<TValidator, TRequest>>();
    }

    public static RouteHandlerBuilder AddValidator<TRequest>(this RouteHandlerBuilder builder, IValidator<TRequest> validator)
    {
        return builder.AddEndpointFilter(new ValidationFilterInstance<TRequest>(validator));
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

            var filter = new ValidationFilter<TValidator, TRequest>();
            return invocationContext => filter.InvokeAsync(invocationContext, next);
        });
    }
}
