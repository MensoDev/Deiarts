using Deiarts.Prototype.Presentation.Web.Client.Services.Materials;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace Deiarts.Prototype.Presentation.Web.Client.Extensions;

public static class BuilderExtensions
{
    public static WebAssemblyHostBuilder AddArchitecture(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddMudServices();
        
        //HttpClient
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        
        return builder;
    }
    
    public static WebAssemblyHostBuilder AddEndpointsClient(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped<IMaterialService, MaterialService>();
        
        return builder;
    }
}