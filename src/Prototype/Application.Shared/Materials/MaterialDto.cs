namespace Deiarts.Prototype.Application.Shared.Materials;

public class MaterialDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal PricePerUnit { get; init; }
}