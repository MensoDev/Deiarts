using Deiarts.Application.RawMaterials;
using Deiarts.Application.RawMaterials.Get;
using Deiarts.Application.RawMaterials.List;
using Deiarts.Common.Extensions;
using Deiarts.Domain.RawMaterials;
using Deiarts.Infrastructure.DbContexts;

namespace Deiarts.Infrastructure.Queries;

internal class RawMaterialQueries(DeiartsDbContext db) : IRawMaterialQueries
{
    public IQueryable<RawMaterial> Queryable() => db.RawMaterials.AsNoTracking().AsQueryable();

    public async Task<ListRawMaterialsResponseItem[]> ListAsync(string? term)
    {
        var query = db.RawMaterials
            .AsNoTracking();

        if (term.IsNotNullOrWhiteSpace())
        {
            query = query.Where(rm => rm.Name.Contains(term) || rm.Brand.Contains(term));
        }
        
        return await query.Select(rm => new ListRawMaterialsResponseItem
            {
                Id = rm.Id,
                Name = rm.Name,
                Brand = rm.Brand,
                Description = rm.Description,
                UnitOfMeasure = rm.UnitOfMeasure,
                CostPerUnit = rm.CostPerUnit
            })
            .ToArrayAsync();
    }

    public Task<GetRawMaterialResponse?> GetAsync(RawMaterialId id)
    {
        return db.RawMaterials
            .AsNoTracking()
            .Where(rm => rm.Id == id)
            .Select(rm => new GetRawMaterialResponse
            {
                Id = rm.Id, 
                Name = rm.Name,
                Brand = rm.Brand,
                Description = rm.Description,
                UnitOfMeasure = rm.UnitOfMeasure,
                CostPerUnit = rm.CostPerUnit
            })
            .FirstOrDefaultAsync();
    }
}