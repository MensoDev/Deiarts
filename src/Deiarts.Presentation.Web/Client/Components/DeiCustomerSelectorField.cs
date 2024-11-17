using Deiarts.Application.Customers.Get;
using Deiarts.Application.Customers.List;
using Deiarts.Common.Client.Components.Forms;
using Deiarts.Common.Client.Services.Endpoints;
using Microsoft.AspNetCore.Components;

namespace Deiarts.Presentation.Web.Client.Components;

public class DeiCustomerSelectorField : DeiSelectorAbstractField<CustomerId>
{
    public DeiCustomerSelectorField()
    {
        Clearable = true;
        Label = "Cliente";
        Placeholder = "Selecione um cliente";
    }
    
    [Inject] public required IEndpointService EndpointService { get; set; }
    
    protected override Func<string, Task<ChoiceOption<CustomerId>[]>> ItemsSearch => SearchAsync;
    protected override Func<CustomerId, Task<ChoiceOption<CustomerId>>> ItemRecover => RecoverAsync;
    
    private async Task<ChoiceOption<CustomerId>> RecoverAsync(CustomerId id)
    {
        var customer = await EndpointService.RequestAsync(new GetCustomerEndpoint(), id);
        return new ChoiceOption<CustomerId>(id, customer.Name);
    }
    
    private async Task<ChoiceOption<CustomerId>[]> SearchAsync(string term)
    {
        var request = new ListCustomersRequest { Term = term };
        var customers = await EndpointService.RequestAsync(new ListCustomersEndpoint(), request);
        
        return customers
            .Select(c => new ChoiceOption<CustomerId>(c.Id, c.Name))
            .ToArray();
    }
}