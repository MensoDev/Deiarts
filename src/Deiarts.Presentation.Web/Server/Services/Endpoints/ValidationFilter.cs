using System.Net;
using FluentValidation;

namespace Deiarts.Presentation.Web.Services.Endpoints;

public class ValidationFilter<TValidator, TRequest> : IEndpointFilter where TValidator : IValidator<TRequest>, new()
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var argumentToValidate = context.GetArgument<TRequest>(0);
        var validator = new TValidator();

        if (argumentToValidate is null)
        {
            return Results.BadRequest($"Request is null or not of type {nameof(TRequest)}");
        }

        var validationResult = await validator.ValidateAsync(argumentToValidate);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary(), statusCode: (int)HttpStatusCode.BadRequest);
        }

        // Otherwise invoke the next filter in the pipeline
        return await next.Invoke(context);
    }
}
