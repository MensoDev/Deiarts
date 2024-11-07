namespace Deiarts.Common.Application.Endpoints;

public abstract class QueryEndpoint<TResponse>(
    //! Cuidado, ele pode sugerir para usar apenas o JsonTypeInfo sem generics, mas isso não é o que queremos,
    //! pois, não teria validação se o JsonTypeInfo é do tipo certo para o request ou response
    JsonTypeInfo<TResponse> responseJsonTypeInfo,
    bool allowAnonymous = false,
    EndpointCacheOutput cacheOutput = EndpointCacheOutput.None)
    : EndpointBase(EndpointMethod.Get, responseJsonTypeInfo, null, allowAnonymous, cacheOutput);

public abstract class QueryEndpoint<TResponse, TRequest>(
    //! Cuidado, ele pode sugerir para usar apenas o JsonTypeInfo sem generics, mas isso não é o que queremos,
    //! pois, não teria validação se o JsonTypeInfo é do tipo certo para o request ou response
    JsonTypeInfo<TResponse> responseJsonTypeInfo,
    JsonTypeInfo<TRequest> requestJsonTypeInfo,
    IValidator<TRequest>? validator = null,
    bool allowAnonymous = false,
    EndpointCacheOutput cacheOutput = EndpointCacheOutput.None)
    : EndpointBase(EndpointMethod.Get, responseJsonTypeInfo, requestJsonTypeInfo, allowAnonymous, cacheOutput)
{
    public IValidator<TRequest>? Validator { get; } = validator;
}