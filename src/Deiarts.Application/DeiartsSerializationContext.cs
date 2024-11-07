using System.Text.Json.Serialization;
using Deiarts.Application.Products.Edit;
using Deiarts.Application.RawMaterials.Edit;
using Deiarts.Application.RawMaterials.Get;
using Deiarts.Application.RawMaterials.List;
using Deiarts.Common.Application;
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]

[JsonSerializable(typeof(EditRawMaterialRequest))]
[JsonSerializable(typeof(ListRawMaterialsResponseItem[]))]
[JsonSerializable(typeof(GetRawMaterialResponse))]
[JsonSerializable(typeof(ValueRequest<RawMaterialId>))]

[JsonSerializable(typeof(EditProductRequest))]
public partial class DeiartsSerializationContext : JsonSerializerContext;