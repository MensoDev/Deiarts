using Deiarts.Application.RawMaterials.Get;
using Deiarts.Application.RawMaterials.List;
using Deiarts.Common;
using Deiarts.Common.Client.Components.Forms;
using Deiarts.Common.Client.Services.Endpoints;
using Deiarts.Domain.RawMaterials;
using Microsoft.AspNetCore.Components;

namespace Deiarts.Presentation.Web.Client.Pages.Products;

public class DeiRawMaterialSelectorField : DeiSelectorAbstractField<RawMaterialId>
{
    public DeiRawMaterialSelectorField()
    {
        Clearable = true;
        Label = "Matéria Prima";
        Placeholder = "Selecione uma matéria prima";
    }
    
    [Inject] public required IEndpointService EndpointService { get; set; }

    protected override Func<string, Task<ChoiceOption<RawMaterialId>[]>> ItemsSearch => SearchAsync;
    protected override Func<RawMaterialId, Task<ChoiceOption<RawMaterialId>>> ItemRecover => RecoverAsync;

    private async Task<ChoiceOption<RawMaterialId>> RecoverAsync(RawMaterialId id)
    {
        var rawMaterial = await EndpointService.RequestAsync(new GetRawMaterialEndpoint(), id);
        return new ChoiceOption<RawMaterialId>(id, rawMaterial.Name);
    }
    
    private async Task<ChoiceOption<RawMaterialId>[]> SearchAsync(string term)
    {
        var request = new ListRawMaterialRequest { Term = term };
        var rawMaterials = await EndpointService.RequestAsync(new ListRawMaterialsEndpoint(), request);
        
        return rawMaterials
            .Select(rm => new ChoiceOption<RawMaterialId>(rm.Id, rm.Name))
            .ToArray();
    }
}