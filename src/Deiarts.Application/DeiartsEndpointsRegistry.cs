using Deiarts.Application.Customers.Edit;
using Deiarts.Application.Customers.Get;
using Deiarts.Application.Products.Edit;
using Deiarts.Application.Products.Get;
using Deiarts.Application.Products.List;
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
            .Register(new RemoveRawMaterialEndpoint(), RemoveRawMaterialEndpoint.ExecuteAsync)

            .Register(new EditProductEndpoint(), EditProductEndpoint.ExecuteAsync)
            .Register(new GetProductEndpoint(), GetProductEndpoint.ExecuteAsync)
            .Register(new ListProductsEndpoint(), ListProductsEndpoint.ExecuteAsync)
            
            .Register(new EditCustomerEndpoint(), EditCustomerEndpoint.ExecuteAsync)
            .Register(new GetCustomerEndpoint(), GetCustomerEndpoint.ExecuteAsync)
            ;
    }
}