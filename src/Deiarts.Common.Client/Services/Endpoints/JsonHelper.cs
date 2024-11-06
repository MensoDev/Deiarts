namespace Deiarts.Common.Client.Services.Endpoints;

public static class JsonHelper
{
    public static async Task<TResponse?> ReadAsResponseAsync<TResponse>(this HttpContent content, EndpointBase endpoint)
    {
        var jsonTypeInfo = GetResponseJsonTypeInfo<TResponse>(endpoint);
        var json = await content.ReadAsStringAsync();
        return JsonSerializer.Deserialize(json, jsonTypeInfo);
    }

    public static JsonTypeInfo<TRequest> GetRequestJsonTypeInfo<TRequest>(EndpointBase endpoint)
    {
        Throw.When.Null(endpoint.RequestJsonTypeInfo, $"JsonTypeInfo não informado para o tipo {typeof(TRequest).Name}");
        return (JsonTypeInfo<TRequest>)endpoint.RequestJsonTypeInfo;
    }

    private static JsonTypeInfo<TResponse> GetResponseJsonTypeInfo<TResponse>(EndpointBase endpoint)
    {
        Throw.When.Null(endpoint.ResponseJsonTypeInfo, $"JsonTypeInfo não informado para o tipo {typeof(TResponse).Name}");
        return (JsonTypeInfo<TResponse>)endpoint.ResponseJsonTypeInfo;
    }
}
