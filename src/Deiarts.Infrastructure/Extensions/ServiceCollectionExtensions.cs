using Deiarts.Application;
using Deiarts.Application.Customers;
using Deiarts.Application.Products;
using Deiarts.Application.Quotations;
using Deiarts.Application.RawMaterials;
using Deiarts.Domain.Customers;
using Deiarts.Domain.Products;
using Deiarts.Domain.Quotations;
using Deiarts.Domain.RawMaterials;
using Deiarts.Infrastructure.Queries;
using Deiarts.Infrastructure.Repositories;
using Deiarts.Infrastructure.Services;
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
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IQuotationRepository, QuotationRepository>();
        
        // Queries
        services.AddScoped<IRawMaterialQueries, RawMaterialQueries>();
        services.AddScoped<IProductQueries, ProductQueries>();
        services.AddScoped<ICustomerQueries, CustomerQueries>();
        services.AddScoped<IQuotationQueries, QuotationQueries>();
        
        // Services
        services.AddScoped<IPricingService, PricingService>();
    }
}