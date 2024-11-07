using Deiarts.Application.RawMaterials.Get;
using Deiarts.Application.RawMaterials.List;
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application.RawMaterials;

internal interface IRawMaterialQueries
{
    IQueryable<RawMaterial> Queryable();
    
    Task<ListRawMaterialsResponseItem[]> ListAsync(string? term);
    Task<GetRawMaterialResponse?> GetAsync(RawMaterialId id);
}