using Deiarts.Common.Domain.Entities;
using Deiarts.Infrastructure.DbContexts;

namespace Deiarts.Infrastructure.Repositories;

internal abstract class BaseRepository<TEntity, TKey>(DeiartsDbContext db) where TEntity : class, IAggregateRoot where TKey : struct
{
    protected DeiartsDbContext Db => db;
    
    public void Add(TEntity entity) => db.Set<TEntity>().Add(entity);
    public async Task<TEntity?> GetAsync(TKey id) => await db.Set<TEntity>().FindAsync(id);
}