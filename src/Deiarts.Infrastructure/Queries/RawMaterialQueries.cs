using Deiarts.Application.RawMaterials;
using Deiarts.Application.RawMaterials.Get;
using Deiarts.Application.RawMaterials.List;
using Deiarts.Domain.RawMaterials;
using Deiarts.Infrastructure.DbContexts;

namespace Deiarts.Infrastructure.Queries;

internal class RawMaterialQueries(DeiartsDbContext db) : IRawMaterialQueries
{
    public IQueryable<RawMaterial> Queryable() => db.RawMaterials.AsQueryable();

    public async Task<ListRawMaterialsResponseItem[]> ListAsync()
    {
        return await db.RawMaterials
            .AsNoTracking()
            .Select(rm => new ListRawMaterialsResponseItem { Id = rm.Id, Name = rm.Name, Description = rm.Description })
            .ToArrayAsync();
    }

    public Task<GetRawMaterialResponse?> GetAsync(RawMaterialId id)
    {
        return db.RawMaterials
            .AsNoTracking()
            .Where(rm => rm.Id == id)
            .Select(rm => new GetRawMaterialResponse { Id = rm.Id, Name = rm.Name, Description = rm.Description })
            .FirstOrDefaultAsync();
    }
}