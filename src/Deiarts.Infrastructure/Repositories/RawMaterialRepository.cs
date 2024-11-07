using Deiarts.Domain.RawMaterials;
using Deiarts.Infrastructure.DbContexts;

namespace Deiarts.Infrastructure.Repositories;

internal class RawMaterialRepository(DeiartsDbContext db) : 
    BaseRepository<RawMaterial, RawMaterialId>(db), 
    IRawMaterialRepository;