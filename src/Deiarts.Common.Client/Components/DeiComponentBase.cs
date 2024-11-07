using Microsoft.AspNetCore.Components;

namespace Deiarts.Common.Client.Components;

public abstract class DeiComponentBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; set; } = [];

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }
}