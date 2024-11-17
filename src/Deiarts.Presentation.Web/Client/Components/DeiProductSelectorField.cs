using Deiarts.Application.Products.Get;
using Deiarts.Application.Products.List;
using Deiarts.Common.Client.Components.Forms;
using Deiarts.Common.Client.Services.Endpoints;
using Microsoft.AspNetCore.Components;

namespace Deiarts.Presentation.Web.Client.Components;

public class DeiProductSelectorField : DeiSelectorAbstractField<ProductId>
{
    public DeiProductSelectorField()
    {
        Clearable = true;
        Label = "Produto";
        Placeholder = "Selecione um produto";
    }
    
    [Inject] public required IEndpointService EndpointService { get; set; }
    
    protected override Func<string, Task<ChoiceOption<ProductId>[]>> ItemsSearch => SearchAsync;
    protected override Func<ProductId, Task<ChoiceOption<ProductId>>> ItemRecover => RecoverAsync;
    
    private async Task<ChoiceOption<ProductId>> RecoverAsync(ProductId id)
    {
        var product = await EndpointService.RequestAsync(new GetProductEndpoint(), id);
        return new ChoiceOption<ProductId>(id, product.Name);
    }
    
    private async Task<ChoiceOption<ProductId>[]> SearchAsync(string term)
    {
        var request = new ListProductsRequest { Term = term };
        var products = await EndpointService.RequestAsync(new ListProductsEndpoint(), request);
        
        return products
            .Select(p => new ChoiceOption<ProductId>(p.Id, p.Name))
            .ToArray();
    }
    
}