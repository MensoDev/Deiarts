using Deiarts.Prototype.Infrastructure.Extensions;
using Deiarts.Prototype.Presentation.Web.Client.Services.Materials;
using Menso.Tools.Exceptions;

namespace Deiarts.Prototype.Presentation.Web.Extensions;

public static class BuilderExtensions
{
    public static WebApplicationBuilder AddArchitectures(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddMudServices();
        
        builder.Services.AddScoped(sp =>
        {
            var hostUrl = builder.Configuration["Host:Url"];
            return new HttpClient { BaseAddress = new Uri(hostUrl!) };
        });
        
        builder.Services.AddSingleton(new ValidatorRepository());
        
        return builder;
    }

    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        Throw.When.Null(connectionString, "Connection string is null");
        
        builder.Services.AddDeiartsInfrastructure(connectionString);
        
        return builder;
    }
    
    public static WebApplicationBuilder AddEndpointsClient(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMaterialService, MaterialService>();
        
        return builder;
    }
}