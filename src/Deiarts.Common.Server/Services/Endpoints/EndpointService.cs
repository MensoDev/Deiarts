using System.Reflection;
using Deiarts.Common.Application.Endpoints;
using Deiarts.Common.Client.Services.Endpoints;
using FluentValidation;
using Menso.Tools.Exceptions;

namespace Deiarts.Common.Server.Services.Endpoints;

internal class EndpointService(IServiceProvider serviceProvider) : IEndpointService
{
    public async Task RequestAsync(CommandEndpoint endpoint) => await SendRequestVoidAsync(endpoint);
    public async Task RequestAsync<TRequest>(CommandEndpoint<TRequest> endpoint, TRequest request)
    {
        await ValidateAsync(endpoint.Validator, request);
        await SendRequestVoidAsync(endpoint, typeof(TRequest), request);
    }
    public async Task<TResponse> RequestAsync<TResponse, TRequest>(CommandEndpoint<TResponse, TRequest> endpoint, TRequest request)
    {
        await ValidateAsync(endpoint.Validator, request);
        return await SendRequestAsync<TResponse>(endpoint, typeof(TRequest), request);
    }
    public async Task<TResponse> RequestAsync<TResponse, TRequest>(QueryEndpoint<TResponse, TRequest> endpoint, TRequest request)
    {
        await ValidateAsync(endpoint.Validator, request);
        return await SendRequestAsync<TResponse>(endpoint, typeof(TRequest), request);
    }
    public Task<TResponse> RequestAsync<TResponse>(CommandWithoutRequestEndpoint<TResponse> endpoint) => SendRequestAsync<TResponse>(endpoint);
    public Task<TResponse> RequestAsync<TResponse>(QueryEndpoint<TResponse> endpoint) => SendRequestAsync<TResponse>(endpoint);
    public Task UploadAsync<TRequest>(UploadFileCommandEndpoint<TRequest> endpoint, TRequest request, FileParameter file)
    {
        throw new InvalidOperationException("UploadAsync não é suportado no modo de renderização do servidor.");
    }
    public Task<TResponse> UploadAsync<TResponse, TRequest>(UploadFileCommandEndpoint<TResponse, TRequest> endpoint, TRequest request, FileParameter file)
    {
        throw new InvalidOperationException("UploadAsync não é suportado no modo de renderização do servidor.");
    }

    private async Task<TResponse> SendRequestAsync<TResponse>(EndpointBase endpoint, Type? requestType = null, object? request = null)
    {
        var endpointInfo = ExtractTypeAndMethodFromEndpoint(endpoint);
        var servicesAndOrRequest = ExtractServicesAndOrRequest(endpointInfo.MethodAsync, serviceProvider, requestType, request);

        var servicesAndOrRequestObjects = servicesAndOrRequest
            .Select(x => x.Value)
            .ToArray();
        
        var task = endpointInfo.MethodAsync.Invoke(null, servicesAndOrRequestObjects) as Task<TResponse>;

        Throw.When.Null(task, $"Não foi possível invocar o método 'ExecuteAsync' em {endpointInfo.Type.Name}");

        var response = await task;
        
        servicesAndOrRequest
            .ToList()
            .ForEach(item => item.TryDisposeValue());
        
        return response;
    }
    private async Task SendRequestVoidAsync(EndpointBase endpoint, Type? requestType = null, object? request = null)
    {
        var endpointInfo = ExtractTypeAndMethodFromEndpoint(endpoint);
        var servicesAndOrRequest = ExtractServicesAndOrRequest(endpointInfo.MethodAsync, serviceProvider, requestType, request);

        var servicesAndOrRequestObjects = servicesAndOrRequest
            .Select(x => x.Value)
            .ToArray();
        
        var task = endpointInfo.MethodAsync.Invoke(null, servicesAndOrRequestObjects) as Task;

        Throw.When.Null(task, $"Não foi possível invocar o método 'ExecuteAsync' em {endpointInfo.Type.Name}");

        await task;
        
        servicesAndOrRequest
            .ToList()
            .ForEach(item => item.TryDisposeValue());
    }
    private static (Type Type, MethodInfo MethodAsync) ExtractTypeAndMethodFromEndpoint(EndpointBase endpoint)
    {
        var endpointType = endpoint.GetType();
#pragma warning disable S3011 // Chamada proposital para que o EndpointService chame diretamente o método Server
        var executeAsyncMethod = endpointType.GetMethod("ExecuteAsync", BindingFlags.NonPublic | BindingFlags.Static);
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields

        Throw.When.Null(executeAsyncMethod, $"Method 'ExecuteAsync' not found in {endpointType.Name}");

        return (endpointType, executeAsyncMethod);
    }

    private static EndpointServiceOrRequestResult[] ExtractServicesAndOrRequest(
        MethodBase executeAsyncMethod,
        IServiceProvider serviceProvider,
        Type? requestType,
        object? request)
    {
        var servicesAndRequest = executeAsyncMethod
            .GetParameters()
            .Select(p => GetServiceOrRequest(p, serviceProvider, requestType, request))
            .ToArray();

        return servicesAndRequest;
    }

    private static EndpointServiceOrRequestResult GetServiceOrRequest(ParameterInfo parameter, IServiceProvider serviceProvider, Type? requestType, object? request)
    {
        var resolver = EndpointServiceServerOptions.GetServiceResolver(parameter.ParameterType);
        
        if(resolver is not null)
        {
            return resolver.ResolveService(serviceProvider);
        }
        
        var value = parameter.ParameterType == requestType ? request : serviceProvider.GetService(parameter.ParameterType);
        
        return new EndpointServiceOrRequestResult
        {
            Value = value,
            RequiredDispose = false
        };
    }

    private static async Task ValidateAsync<TRequest>(IValidator<TRequest>? validator, TRequest request)
    {
        if (validator is null) return;
        await validator.ValidateAsync(request);
    }
}