using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Deiarts.Common.Client.Services.Endpoints;

internal class EndpointService(HttpClient client) : IEndpointService
{
    public async Task RequestAsync(CommandEndpoint endpoint) => await SendRequestAsync(endpoint);
    public async Task RequestAsync<TRequest>(CommandEndpoint<TRequest> endpoint, TRequest request) => await SendCommandRequestAsync(endpoint, request);
    public async Task<TResponse> RequestAsync<TResponse, TRequest>(CommandEndpoint<TResponse, TRequest> endpoint, TRequest request) => await SendRequestAsync(endpoint, request);
    public async Task<TResponse> RequestAsync<TResponse>(CommandWithoutRequestEndpoint<TResponse> endpoint) => await SendRequestAsync(endpoint);
    public async Task<TResponse> RequestAsync<TResponse, TRequest>(QueryEndpoint<TResponse, TRequest> endpoint, TRequest request) => await SendRequestAsync(endpoint, request);
    public async Task<TResponse> RequestAsync<TResponse>(QueryEndpoint<TResponse> endpoint) => await SendRequestAsync(endpoint);
    public async Task UploadAsync<TRequest>(UploadFileCommandEndpoint<TRequest> endpoint, TRequest request, FileParameter file)
    {
        using var content = new MultipartFormDataContent();

        var streamContent = new StreamContent(file.Stream);
        streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);

        content.Add(streamContent, "file", file.Name.RemoveNonSpacingMark());

        var queryString = QueryStringHelper.ToQueryString(request, JsonHelper.GetRequestJsonTypeInfo<TRequest>(endpoint));
        var path = $"{endpoint.Path}?{queryString}";

        var response = await client.PostAsync(path, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task<TResponse> UploadAsync<TResponse, TRequest>(UploadFileCommandEndpoint<TResponse, TRequest> endpoint, TRequest request, FileParameter file)
    {
        using var content = new MultipartFormDataContent();

        var streamContent = new StreamContent(file.Stream);
        streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);

        content.Add(streamContent, "file", file.Name.RemoveNonSpacingMark());

        var queryString = QueryStringHelper.ToQueryString(request, JsonHelper.GetRequestJsonTypeInfo<TRequest>(endpoint));
        var path = $"{endpoint.Path}?{queryString}";

        var response = await client.PostAsync(path, content);

        return (await response.Content.ReadAsResponseAsync<TResponse>(endpoint))!;
    }

    private async Task SendRequestAsync(EndpointBase endpoint)
    {
        var path = endpoint.Path;
        var method = endpoint.GetHttpMethod;

        var request = new HttpRequestMessage(method, path);
        var response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }
    private async Task<TResponse> SendRequestAsync<TResponse>(CommandWithoutRequestEndpoint<TResponse> endpoint)
    {
        var path = endpoint.Path;
        var method = endpoint.GetHttpMethod;

        var request = new HttpRequestMessage(method, path);
        var response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return (await response.Content.ReadAsResponseAsync<TResponse>(endpoint))!;
    }
    private async Task<TResponse> SendRequestAsync<TResponse>(QueryEndpoint<TResponse> endpoint)
    {
        var path = endpoint.Path;
        var method = endpoint.GetHttpMethod;

        var request = new HttpRequestMessage(method, path);
        var response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return (await response.Content.ReadAsResponseAsync<TResponse>(endpoint))!;
    }
    private async Task<TResponse> SendRequestAsync<TResponse, TRequest>(QueryEndpoint<TResponse, TRequest> endpoint, TRequest request)
    {
        var path = endpoint.Path;
        var method = endpoint.GetHttpMethod;

        Throw.When.Null(request, $"Request ({typeof(TRequest).Name}) is null ");
        var queryString = QueryStringHelper.ToQueryString(request, JsonHelper.GetRequestJsonTypeInfo<TRequest>(endpoint));
        path = $"{path}?{queryString}";

        var requestMessage = new HttpRequestMessage(method, path);


        var responseMessage = await client.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();

        return (await responseMessage.Content.ReadAsResponseAsync<TResponse>(endpoint))!;
    }
    private async Task<TResponse> SendRequestAsync<TResponse, TRequest>(CommandEndpoint<TResponse, TRequest> endpoint, TRequest request)
    {
        var path = endpoint.Path;
        var method = endpoint.GetHttpMethod;

        var requestMessage = new HttpRequestMessage(method, path)
        {
            Content = JsonContent.Create(request, JsonHelper.GetRequestJsonTypeInfo<TRequest>(endpoint))
        };

        var responseMessage = await client.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();

        return (await responseMessage.Content.ReadAsResponseAsync<TResponse>(endpoint))!;
    }
    private async Task SendCommandRequestAsync<TRequest>(CommandEndpoint<TRequest> endpoint, TRequest request)
    {
        var path = endpoint.Path;
        var method = endpoint.GetHttpMethod;

        var requestMessage = new HttpRequestMessage(method, path)
        {
            Content = JsonContent.Create(request, JsonHelper.GetRequestJsonTypeInfo<TRequest>(endpoint))
        };

        var responseMessage = await client.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();
    }
}
