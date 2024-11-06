namespace Deiarts.Common.Application.Endpoints;

public abstract class CommandWithoutRequestEndpoint<TResponse>(
    //! Cuidado, ele pode sugerir para usar apenas o JsonTypeInfo sem generics, mas isso não é o que queremos,
    //! pois, não teria validação se o JsonTypeInfo é do tipo certo para o request ou response
    JsonTypeInfo<TResponse> responseJsonTypeInfo,
    bool allowAnonymous = false,
    EndpointCacheOutput cacheOutput = EndpointCacheOutput.None) : EndpointBase(EndpointMethod.Post, responseJsonTypeInfo, null, allowAnonymous, cacheOutput) {}
