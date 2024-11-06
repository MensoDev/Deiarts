using System.Text.Json.Serialization;
using Deiarts.Common.Client.ProblemDetails;

namespace Deiarts.Common.Client;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(ProblemDetailsException))]
public partial class CommonClientSerializationContext : JsonSerializerContext;