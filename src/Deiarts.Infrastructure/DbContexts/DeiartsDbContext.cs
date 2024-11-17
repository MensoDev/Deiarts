using Deiarts.Domain.Customers;
using Deiarts.Domain.Products;
using Deiarts.Domain.Quotations;
using Deiarts.Domain.RawMaterials;
using Deiarts.Infrastructure.Configurations;

namespace Deiarts.Infrastructure.DbContexts;

internal class DeiartsDbContext(DbContextOptions<DeiartsDbContext> options) : DbContext(options), IUnitOfWork
{
    public required DbSet<Customer> Customers { get; init; }
    public required DbSet<Product> Products { get; init; }
    public required DbSet<ProductComposition> ProductCompositions { get; init; }
    public required DbSet<RawMaterial> RawMaterials { get; init; }
    public required DbSet<Quotation> Quotations { get; init; }
    public required DbSet<QuotationItem> QuotationItems { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCompositionConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new RawMaterialConfiguration());
        modelBuilder.ApplyConfiguration(new QuotationConfiguration());
        modelBuilder.ApplyConfiguration(new QuotationItemConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<CustomerId>().HaveConversion<CustomerId.EfCoreValueConverter>();
        configurationBuilder.Properties<ProductCompositionId>().HaveConversion<ProductCompositionId.EfCoreValueConverter>();
        configurationBuilder.Properties<ProductId>().HaveConversion<ProductId.EfCoreValueConverter>();
        configurationBuilder.Properties<RawMaterialId>().HaveConversion<RawMaterialId.EfCoreValueConverter>();
        configurationBuilder.Properties<QuotationId>().HaveConversion<QuotationId.EfCoreValueConverter>();
        configurationBuilder.Properties<QuotationItemId>().HaveConversion<QuotationItemId.EfCoreValueConverter>();
    }

    public new Task SaveChangesAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync(cancellationToken);
}