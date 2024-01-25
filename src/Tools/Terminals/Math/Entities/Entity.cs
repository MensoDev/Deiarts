namespace Deiarts.Tools.Terminals.MathBudget.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }
    public Guid Code { get; protected set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; protected set; } = DateTime.UtcNow;
}