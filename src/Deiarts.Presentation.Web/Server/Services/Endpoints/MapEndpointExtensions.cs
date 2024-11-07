using Deiarts.Common.Application.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace Deiarts.Presentation.Web.Services.Endpoints;

public static class MapEndpointExtensions
{
    public static IEndpointRouteBuilder MapEndpoints(
        this IEndpointRouteBuilder endpoints,
        params Action<IEndpointRegistry>[] registrators)
    {
        var registry = new EndpointRegistry(endpoints);
        registrators.ToList().ForEach(r => r(registry));
        return endpoints;
    }

    public static IEndpointRouteBuilder MapUploadEndpoint<TRequest, TParameters>(
        this IEndpointRouteBuilder endpoints,
        UploadFileCommandEndpoint<TRequest> endpoint,
        Delegate del) where TParameters : TRequest
    {

        var routeBuilder = endpoints.MapPost(endpoint.Path, async (
            [AsParameters] TParameters parameters,
            [FromForm] IFormFile file) =>
        {
            var fileParameter = new FileParameter
            {
                Name = file.FileName,
                Stream = file.OpenReadStream(),
                ContentType = file.ContentType
            };

            await (Task)del.DynamicInvoke(parameters, fileParameter)!;
        });

        routeBuilder.DisableAntiforgery();

        if (endpoint.AllowAnonymous)
        {
            routeBuilder.AllowAnonymous();
        }
        else
        {
            routeBuilder.RequireAuthorization();
        }

        return endpoints;
    }

    public static IEndpointRouteBuilder MapUploadEndpoint<TResponse, TRequest, TParameters>(
        this IEndpointRouteBuilder endpoints,
        UploadFileCommandEndpoint<TResponse, TRequest> endpoint,
        Delegate del) where TParameters : TRequest
    {

        var routeBuilder = endpoints.MapPost(endpoint.Path, async (
            [AsParameters] TParameters parameters,
            [FromForm] IFormFile file) =>
        {
            var fileParameter = new FileParameter
            {
                Name = file.FileName,
                Stream = file.OpenReadStream(),
                ContentType = file.ContentType
            };

            var response = await (Task<TResponse>)del.DynamicInvoke(parameters, fileParameter)!;
            return Results.Ok(response);
        });

        routeBuilder.DisableAntiforgery();

        if (endpoint.AllowAnonymous)
        {
            routeBuilder.AllowAnonymous();
        }
        else
        {
            routeBuilder.RequireAuthorization();
        }

        return endpoints;
    }

    public static IEndpointRouteBuilder MapCettproEndpoint(
        this IEndpointRouteBuilder endpoints,
        EndpointBase endpoint,
        Delegate del)
    {
        endpoints.MapCettproRequest(endpoint, del);
        return endpoints;
    }

    public static IEndpointRouteBuilder MapCettproEndpoint<TRequest>(
        this IEndpointRouteBuilder endpoints,
        CommandEndpoint<TRequest> endpoint,
        Delegate del)
    {
        var end = endpoints.MapCettproRequest(endpoint, del);
        if (endpoint.Validator is not null)
        {
            end.AddValidator(endpoint.Validator);
        }
        return endpoints;
    }

    public static IEndpointRouteBuilder MapCettproEndpoint<TResponse, TRequest>(
        this IEndpointRouteBuilder endpoints,
        QueryEndpoint<TResponse, TRequest> endpoint,
        Delegate del)
    {
        var end = endpoints.MapCettproRequest(endpoint, del);
        if (endpoint.Validator is not null)
        {
            end.AddValidator(endpoint.Validator);
        }

        return endpoints;
    }

    public static IEndpointRouteBuilder MapCettproEndpoint<TResponse, TRequest>(
        this IEndpointRouteBuilder endpoints,
        CommandEndpoint<TResponse, TRequest> endpoint,
        Delegate del)
    {
        var end = endpoints.MapCettproRequest(endpoint, del);
        if (endpoint.Validator is not null)
        {
            end.AddValidator(endpoint.Validator);
        }
        return endpoints;
    }

    private static RouteHandlerBuilder MapCettproRequest(this IEndpointRouteBuilder endpoints, EndpointBase endpoint, Delegate del)
    {
        var routeBuilder = endpoint.Method switch
        {
            EndpointMethod.Get => endpoints.MapGet(endpoint.Path, del),
            EndpointMethod.Post => endpoints.MapPost(endpoint.Path, del),
            _ => throw new NotImplementedException()
        };

        if (endpoint.CacheOutput is not EndpointCacheOutput.None)
        {
            routeBuilder.CacheOutput(endpoint.CacheOutputPolicy);
        }

        if (endpoint.AllowAnonymous)
        {
            routeBuilder.AllowAnonymous();
        }
        else
        {
            routeBuilder.RequireAuthorization();
        }
        return routeBuilder;
    }
}
