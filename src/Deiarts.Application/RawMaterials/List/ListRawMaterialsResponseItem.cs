using Deiarts.Domain.Enums;
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application.RawMaterials.List;

public class ListRawMaterialsResponseItem
{
    public required RawMaterialId Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required UnitOfMeasureType UnitOfMeasure { get; init; }
    public required decimal CostPerUnit { get; init; }
}