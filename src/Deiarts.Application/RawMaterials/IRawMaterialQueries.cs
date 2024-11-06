using Deiarts.Application.RawMaterials.Get;
using Deiarts.Application.RawMaterials.List;
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application.RawMaterials;

public interface IRawMaterialQueries
{
    IQueryable<RawMaterial> Queryable();
    
    Task<ListRawMaterialsResponseItem[]> ListAsync();
    Task<GetRawMaterialResponse?> GetAsync(RawMaterialId id);
}