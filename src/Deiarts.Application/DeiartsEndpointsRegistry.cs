using Deiarts.Application.RawMaterials.Edit;
using Deiarts.Application.RawMaterials.Get;
using Deiarts.Application.RawMaterials.List;
using Deiarts.Application.RawMaterials.Remove;

namespace Deiarts.Application;

public static class DeiartsEndpointsRegistry
{
    public static void Register(IEndpointRegistry registry)
    {
        registry
            .Register(new EditRawMaterialEndpoint(), EditRawMaterialEndpoint.ExecuteAsync)
            .Register(new GetRawMaterialEndpoint(), GetRawMaterialEndpoint.ExecuteAsync)
            .Register(new ListRawMaterialsEndpoint(), ListRawMaterialsEndpoint.ExecuteAsync)
            .Register(new RemoveRawMaterialEndpoint(), RemoveRawMaterialEndpoint.ExecuteAsync);
    }
}