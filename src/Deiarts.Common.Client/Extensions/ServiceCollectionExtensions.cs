using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace Deiarts.Common.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonClientServices(this IServiceCollection services, bool isServer = false)
    {
        services.AddMudServices();
        return services;
    }
}