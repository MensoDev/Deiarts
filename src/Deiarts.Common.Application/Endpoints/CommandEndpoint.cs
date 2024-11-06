namespace Deiarts.Common.Application.Endpoints;

public abstract class CommandEndpoint(bool allowAnonymous = false) : EndpointBase(EndpointMethod.Post, null, null, allowAnonymous);

public abstract class CommandEndpoint<TResponse, TRequest>(
    //! Cuidado, ele pode sugerir para usar apenas o JsonTypeInfo sem generics, mas isso não é o que queremos,
    //! pois, não teria validação se o JsonTypeInfo é do tipo certo para o request ou response
    JsonTypeInfo<TResponse> responseJsonTypeInfo,
    JsonTypeInfo<TRequest> requestJsonTypeInfo,
    IValidator<TRequest>? validator = null,
    bool allowAnonymous = false)
    : EndpointBase(EndpointMethod.Post, responseJsonTypeInfo, requestJsonTypeInfo, allowAnonymous)
{
    public IValidator<TRequest>? Validator { get; } = validator;
}

public abstract class CommandEndpoint<TRequest>(
    //! Cuidado, ele pode sugerir para usar apenas o JsonTypeInfo sem generics, mas isso não é o que queremos,
    //! pois, não teria validação se o JsonTypeInfo é do tipo certo para o request ou response
    JsonTypeInfo<TRequest> requestJsonTypeInfo,
    IValidator<TRequest>? validator = null,
    bool allowAnonymous = false)
    : EndpointBase(EndpointMethod.Post, null, requestJsonTypeInfo, allowAnonymous)
{
    public IValidator<TRequest>? Validator { get; } = validator;
}