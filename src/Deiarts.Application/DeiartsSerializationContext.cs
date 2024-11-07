using System.Text.Json.Serialization;
using Deiarts.Application.Products.Edit;
using Deiarts.Application.Products.Get;
using Deiarts.Application.Products.List;
using Deiarts.Application.RawMaterials.Edit;
using Deiarts.Application.RawMaterials.Get;
using Deiarts.Application.RawMaterials.List;
using Deiarts.Domain.Products;
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]

[JsonSerializable(typeof(EditRawMaterialRequest))]
[JsonSerializable(typeof(GetRawMaterialResponse))]
[JsonSerializable(typeof(ListRawMaterialRequest))]
[JsonSerializable(typeof(ListRawMaterialsResponseItem[]))]
[JsonSerializable(typeof(ValueRequest<RawMaterialId>))]

[JsonSerializable(typeof(EditProductRequest))]
[JsonSerializable(typeof(GetProductResponse))]
[JsonSerializable(typeof(ListProductsResponseItem[]))]
[JsonSerializable(typeof(ValueRequest<ProductId>))]

public partial class DeiartsSerializationContext : JsonSerializerContext;