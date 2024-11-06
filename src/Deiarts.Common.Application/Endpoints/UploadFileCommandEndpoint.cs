using System.Text.Json.Serialization;

namespace Deiarts.Common.Application.Endpoints;

public abstract class UploadFileCommandEndpoint<TRequest>(
    //! Cuidado, ele pode sugerir para usar apenas o JsonTypeInfo sem generics, mas isso não é o que queremos,
    //! pois, não teria validação se o JsonTypeInfo é do tipo certo para o request ou response
    JsonTypeInfo<TRequest> requestJsonTypeInfo,
    bool allowAnonymous = false)
    : EndpointBase(EndpointMethod.Post, null, requestJsonTypeInfo, allowAnonymous);

public abstract class UploadFileCommandEndpoint<TResponse, TRequest>(
    //! Cuidado, ele pode sugerir para usar apenas o JsonTypeInfo sem generics, mas isso não é o que queremos,
    //! pois, não teria validação se o JsonTypeInfo é do tipo certo para o request ou response
    JsonTypeInfo<TResponse> responseJsonTypeInfo,
    JsonTypeInfo<TRequest> requestJsonTypeInfo,
    bool allowAnonymous = false)
    : EndpointBase(EndpointMethod.Post, responseJsonTypeInfo, requestJsonTypeInfo, allowAnonymous);

public class FileParameter
{
    public required string Name { get; init; }
    [JsonIgnore]
    public string NameWithoutExtension => Path.GetFileNameWithoutExtension(Name);
    [JsonIgnore]
    public string Extension => Path.GetExtension(Name);
    public required Stream Stream { get; init; }
    public required string ContentType { get; init; }
}