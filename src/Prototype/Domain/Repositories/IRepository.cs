namespace Deiarts.Prototype.Domain.Repositories;

public interface IRepository<TEntity>
{
    ValueTask<TEntity?> GetAsync(Guid id);
    void Add(TEntity entity);
    IQueryable<TEntity> GetQueryable();
    Task SaveChangesAsync();
}