using Deiarts.Common.Client.Services.Endpoints;
using Deiarts.Common.Client.Services.Ui;
using Deiarts.Common.Server.Services.Endpoints;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace Deiarts.Common.Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonServerServices(this IServiceCollection services)
    {
        services.AddProblemDetails();
        
        services.AddExceptionHandler<ExceptionToProblemDetailsHandler>();
        
        services.AddScoped<IEndpointService, EndpointService>();
        services.AddScoped<IUiUtils, UiUtils>();
        
        services.AddMudServices();
        return services;
    }
}