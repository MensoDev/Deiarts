using Deiarts.Domain.RawMaterials;
using Deiarts.Infrastructure.Configurations;

namespace Deiarts.Infrastructure.DbContexts;

public class DeiartsDbContext(DbContextOptions<DeiartsDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RawMaterialConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<RawMaterialId>().HaveConversion<RawMaterialId.EfCoreValueConverter>();
    }
}