namespace Deiarts.Prototype.Domain.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    
    public override bool Equals(object? obj)
    {
        if (obj is not Entity other) return false;

        if (ReferenceEquals(this, other)) return true;

        if (GetUnproxiedType(this) != GetUnproxiedType(other)) return false;

        if (Id.Equals(Guid.Empty) || other.Id.Equals(Guid.Empty)) return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return (GetUnproxiedType(this).ToString() + Id).GetHashCode();
    }
    
    private static Type GetUnproxiedType(object obj)
    {
        const string efCoreProxyPrefix = "Castle.Proxies.";
        const string nHibernateProxyPostfix = "Proxy";

        var type = obj.GetType();
        var typeString = type.ToString();

        if (typeString.Contains(efCoreProxyPrefix) || typeString.EndsWith(nHibernateProxyPostfix)) return type.BaseType!;
        return type;
    }
}