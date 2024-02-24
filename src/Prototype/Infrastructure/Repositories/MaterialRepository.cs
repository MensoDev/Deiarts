using Deiarts.Prototype.Domain.Entities;
using Deiarts.Prototype.Domain.Repositories;
using Deiarts.Prototype.Infrastructure.Contexts;

namespace Deiarts.Prototype.Infrastructure.Repositories;

public class MaterialRepository(DeiartsDbContext deiartsDbContext) : Repository<Material>(deiartsDbContext), IMaterialRepository;
