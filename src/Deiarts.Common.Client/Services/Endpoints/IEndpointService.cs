namespace Deiarts.Common.Client.Services.Endpoints;

public interface IEndpointService
{
    Task RequestAsync(CommandEndpoint endpoint);
    Task RequestAsync<TRequest>(CommandEndpoint<TRequest> endpoint, TRequest request);
    Task<TResponse> RequestAsync<TResponse>(CommandWithoutRequestEndpoint<TResponse> endpoint);
    Task<TResponse> RequestAsync<TResponse, TRequest>(CommandEndpoint<TResponse, TRequest> endpoint, TRequest request);
    Task<TResponse> RequestAsync<TResponse, TRequest>(QueryEndpoint<TResponse, TRequest> endpoint, TRequest request);
    Task<TResponse> RequestAsync<TResponse>(QueryEndpoint<TResponse> endpoint);

    Task UploadAsync<TRequest>(UploadFileCommandEndpoint<TRequest> endpoint, TRequest request, FileParameter file);
    Task<TResponse> UploadAsync<TResponse, TRequest>(UploadFileCommandEndpoint<TResponse, TRequest> endpoint, TRequest request, FileParameter file);
}
