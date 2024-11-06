using Deiarts.Domain.RawMaterials;
using Deiarts.Infrastructure.DbContexts;
using Deiarts.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Deiarts.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDeiartsInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<DeiartsDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DeiartsConnection"));
        });
        
        services.AddScoped<IRawMaterialRepository, RawMaterialRepository>();
    }
}