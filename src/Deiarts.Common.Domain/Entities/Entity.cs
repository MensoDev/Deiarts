namespace Deiarts.Common.Domain.Entities;

public abstract class Entity<TKey> : IEqualityComparer<Entity<TKey>> where TKey : struct
{
    public TKey Id { get; protected set; }
    
    public bool Equals(Entity<TKey>? x, Entity<TKey>? y)
    {
        if(x is null && y is null)
        {
            return true;
        }
        
        if(x is null || y is null)
        {
            return false;
        }
        
        return x.Id.Equals(y.Id);
    }

    public int GetHashCode(Entity<TKey> obj)
    {
        return obj.Id.GetHashCode();
    }
}