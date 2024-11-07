using Deiarts.Domain;
using Deiarts.Domain.RawMaterials;
using Deiarts.Infrastructure.Configurations;

namespace Deiarts.Infrastructure.DbContexts;

internal class DeiartsDbContext(DbContextOptions<DeiartsDbContext> options) : DbContext(options), IUnitOfWork
{
    public required DbSet<RawMaterial> RawMaterials { get; init; }
    
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

    public new Task SaveChangesAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync(cancellationToken);
}