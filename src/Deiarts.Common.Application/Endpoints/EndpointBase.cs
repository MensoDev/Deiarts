namespace Deiarts.Common.Application.Endpoints;

public abstract class EndpointBase(
    EndpointMethod method,
    JsonTypeInfo? responseJsonTypeInfo,
    JsonTypeInfo? requestJsonTypeInfo,
    bool allowAnonymous = false,
    EndpointCacheOutput cacheOutput = EndpointCacheOutput.None)
{
    public bool AllowAnonymous { get; } = allowAnonymous;
    public EndpointCacheOutput CacheOutput { get; } = cacheOutput;
    public EndpointMethod Method { get; } = method;
    public JsonTypeInfo? ResponseJsonTypeInfo { get; } = responseJsonTypeInfo;
    public JsonTypeInfo? RequestJsonTypeInfo { get; } = requestJsonTypeInfo;
    public string CacheOutputPolicy => CacheOutput.ToString();
    public string Path => $"api/{GetType().FullName!.Replace(".", "/")}";
    
    public HttpMethod GetHttpMethod => Method switch
    {
        EndpointMethod.Get => HttpMethod.Get,
        EndpointMethod.Post => HttpMethod.Post,
        _ => throw new NotImplementedException()
    };
}