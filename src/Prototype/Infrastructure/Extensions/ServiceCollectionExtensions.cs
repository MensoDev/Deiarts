using Deiarts.Prototype.Domain.Repositories;
using Deiarts.Prototype.Infrastructure.Contexts;
using Deiarts.Prototype.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Deiarts.Prototype.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDeiartsInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DeiartsDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IMaterialRepository, MaterialRepository>();
    }
}