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

        if (isServer) return services;
        
        services.AddScoped<IEndpointService, EndpointService>();
        services.AddScoped<IUiUtils, UiUtils>();

        return services;
    }
}