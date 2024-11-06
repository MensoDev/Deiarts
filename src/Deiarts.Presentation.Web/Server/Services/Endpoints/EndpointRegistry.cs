using Deiarts.Common.Application.Endpoints;

namespace Deiarts.Presentation.Web.Services.Endpoints;
public class EndpointRegistry(IEndpointRouteBuilder endpoints) : IEndpointRegistry
{
    public IEndpointRegistry Register(EndpointBase endpoint, Delegate del)
    {
        endpoints.MapCettproEndpoint(endpoint, del);
        return this;
    }

    public IEndpointRegistry Register(CommandEndpoint endpoint, Delegate del)
    {
        endpoints.MapCettproEndpoint(endpoint, del);
        return this;
    }

    public IEndpointRegistry Register<TRequest>(CommandEndpoint<TRequest> endpoint, Delegate del)
    {
        endpoints.MapCettproEndpoint(endpoint, del);
        return this;
    }

    public IEndpointRegistry Register<TResponse, TRequest>(CommandEndpoint<TResponse, TRequest> endpoint, Delegate del)
    {
        endpoints.MapCettproEndpoint(endpoint, del);
        return this;
    }

    public IEndpointRegistry Register<TResponse>(QueryEndpoint<TResponse> endpoint, Delegate del)
    {
        endpoints.MapCettproEndpoint(endpoint, del);
        return this;
    }

    public IEndpointRegistry Register<TResponse, TRequest>(QueryEndpoint<TResponse, TRequest> endpoint, Delegate del)
    {
        endpoints.MapCettproEndpoint(endpoint, del);
        return this;
    }

    public IEndpointRegistry RegisterUpload<TRequest, TParameters>(UploadFileCommandEndpoint<TRequest> endpoint, Delegate del)
        where TParameters : TRequest
    {
        endpoints.MapUploadEndpoint<TRequest, TParameters>(endpoint, del);
        return this;
    }

    public IEndpointRegistry RegisterUpload<TResponse, TRequest, TParameters>(UploadFileCommandEndpoint<TResponse, TRequest> endpoint, Delegate del) where TParameters : TRequest
    {
        endpoints.MapUploadEndpoint<TResponse, TRequest, TParameters>(endpoint, del);
        return this;
    }
}
