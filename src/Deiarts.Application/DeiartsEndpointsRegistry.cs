using Deiarts.Application.Customers.Edit;
using Deiarts.Application.Customers.Get;
using Deiarts.Application.Customers.List;
using Deiarts.Application.Customers.Remove;
using Deiarts.Application.Products.Edit;
using Deiarts.Application.Products.Get;
using Deiarts.Application.Products.List;
using Deiarts.Application.Quotations.Create;
using Deiarts.Application.Quotations.EditeItem;
using Deiarts.Application.Quotations.Get;
using Deiarts.Application.Quotations.GetItem;
using Deiarts.Application.Quotations.List;
using Deiarts.Application.Quotations.RemoveItem;
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
            .Register(new ListCustomersEndpoint(), ListCustomersEndpoint.ExecuteAsync)
            .Register(new RemoveCustomerEndpoint(), RemoveCustomerEndpoint.ExecuteAsync)
            
            .Register(new CreateQuotationEndpoint(), CreateQuotationEndpoint.ExecuteAsync)
            .Register(new ListQuotationsEndpoint(), ListQuotationsEndpoint.ExecuteAsync)
            .Register(new GetQuotationEndpoint(), GetQuotationEndpoint.ExecuteAsync)
            .Register(new EditQuotationItemEndpoint(), EditQuotationItemEndpoint.ExecuteAsync)
            .Register(new RemoveQuotationItemEndpoint(), RemoveQuotationItemEndpoint.ExecuteAsync)
            .Register(new GetQuotationItemEndpoint(), GetQuotationItemEndpoint.ExecuteAsync)
            ;
    }
}