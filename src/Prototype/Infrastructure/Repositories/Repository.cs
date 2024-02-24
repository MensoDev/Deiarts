using Deiarts.Prototype.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Deiarts.Prototype.Infrastructure.Repositories;

public class Repository<TEntity>(DbContext deiartsDbContext) : IRepository<TEntity> where TEntity : class
{
    public async ValueTask<TEntity?> GetAsync(Guid id) => await deiartsDbContext.Set<TEntity>().FindAsync(id);
    public void Add(TEntity entity) => deiartsDbContext.Set<TEntity>().Add(entity);
    public IQueryable<TEntity> GetQueryable() => deiartsDbContext.Set<TEntity>().AsQueryable();
    public async Task SaveChangesAsync() => await deiartsDbContext.SaveChangesAsync();
}