using Deiarts.Domain.RawMaterials;

namespace Deiarts.Infrastructure.Repositories;

internal class RawMaterialRepository(DeiartsDbContext db) : 
    BaseRepository<RawMaterial, RawMaterialId>(db), 
    IRawMaterialRepository;