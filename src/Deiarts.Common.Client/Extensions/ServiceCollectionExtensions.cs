using BlazorDevKit;
using Deiarts.Common.Client.Components.Loaders;
using Deiarts.Common.Client.Services.Endpoints;
using Deiarts.Common.Client.Services.Ui;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace Deiarts.Common.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonClientServices(this IServiceCollection services, bool isServer = false)
    {
        services.AddMudServices();
        services.AddScoped<IUiUtils, UiUtils>();
        
        if (isServer) return services;
        
        services.AddScoped<IEndpointService, EndpointService>();

        return services;
    }

    public static void ConfigureLoaderOptions(this IServiceCollection _)
    {
        BdkLoaderOptions.Loading.ChangeContent<DeiLoadingContent>();
        BdkLoaderOptions.Error.RegisterContent<Exception, DeiDefaultErrorContent>();
    }
}