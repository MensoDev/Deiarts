using Deiarts.Application.Products;
using Deiarts.Application.RawMaterials;
using Deiarts.Domain;
using Deiarts.Domain.Products;
using Deiarts.Domain.RawMaterials;
using Deiarts.Infrastructure.DbContexts;
using Deiarts.Infrastructure.Queries;
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

        // Suporte services
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<DeiartsDbContext>());
        
        // Repositories
        services.AddScoped<IRawMaterialRepository, RawMaterialRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        
        // Queries
        services.AddScoped<IRawMaterialQueries, RawMaterialQueries>();
        services.AddScoped<IProductQueries, ProductQueries>();
    }
}