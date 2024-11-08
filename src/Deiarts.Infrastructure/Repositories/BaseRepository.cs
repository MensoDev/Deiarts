using Deiarts.Common.Domain.Entities;

namespace Deiarts.Infrastructure.Repositories;

internal abstract class BaseRepository<TEntity, TKey>(DeiartsDbContext db) where TEntity : class, IAggregateRoot where TKey : struct
{
    protected DeiartsDbContext Db => db;
    
    public void Add(TEntity entity) => db.Set<TEntity>().Add(entity);
    public void Remove(TEntity entity) => db.Set<TEntity>().Remove(entity);
    public async Task<TEntity?> GetAsync(TKey id) => await db.Set<TEntity>().FindAsync(id);
}