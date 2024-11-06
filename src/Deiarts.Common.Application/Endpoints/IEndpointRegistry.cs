namespace Deiarts.Common.Application.Endpoints;

public interface IEndpointRegistry
{
    //IEndpointRegistry Register(EndpointBase endpoint, Delegate del);
    IEndpointRegistry Register(CommandEndpoint endpoint, Delegate del);
    IEndpointRegistry Register<TRequest>(CommandEndpoint<TRequest> endpoint, Delegate del);
    IEndpointRegistry Register<TResponse, TRequest>(CommandEndpoint<TResponse, TRequest> endpoint, Delegate del);
    IEndpointRegistry Register<TResponse>(QueryEndpoint<TResponse> endpoint, Delegate del);
    IEndpointRegistry Register<TResponse, TRequest>(QueryEndpoint<TResponse, TRequest> endpoint, Delegate del);
    IEndpointRegistry RegisterUpload<TRequest, TParameters>(UploadFileCommandEndpoint<TRequest> endpoint, Delegate del) where TParameters : TRequest;
    IEndpointRegistry RegisterUpload<TResponse, TRequest, TParameters>(UploadFileCommandEndpoint<TResponse, TRequest> endpoint, Delegate del) where TParameters : TRequest;
}