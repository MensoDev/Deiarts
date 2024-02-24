using Microsoft.AspNetCore.Components.Web;

namespace Deiarts.Prototype.Presentation.Web.Client;

public static class CustomRenderModes
{
    public static readonly InteractiveAutoRenderMode InteractiveAutoNoPreRender = new(prerender: false);
    public static readonly InteractiveServerRenderMode InteractiveServerNoPreRender = new(prerender: false);
    public static readonly InteractiveWebAssemblyRenderMode InteractiveWebAssemblyNoPreRender = new(prerender: false);
}