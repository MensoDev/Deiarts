using Cblx.Blocks;
using Deiarts.Common.Domain.Entities;
using Deiarts.Domain.Enums;

namespace Deiarts.Domain.RawMaterials;

[StronglyTypedId] public readonly partial struct RawMaterialId;

[HasPrivateEmptyConstructor]
internal partial class RawMaterial : Entity<RawMaterialId>, IAggregateRoot
{
    public RawMaterial(string name, string brand, string description, UnitOfMeasureType unitOfMeasure, decimal costPerUnit)
    {
        Name = name;
        Brand = brand;
        Description = description;
        UnitOfMeasure = unitOfMeasure;
        CostPerUnit = costPerUnit;
    }
    
    public string Name { get; private set; }
    public string Brand { get; private set; }
    public string Description { get; private set; }

    public UnitOfMeasureType UnitOfMeasure { get; private set; }
    public decimal CostPerUnit { get; private set; }
    
    public void Update(string name, string brand, string description, UnitOfMeasureType unitOfMeasure, decimal costPerUnit)
    {
        Name = name;
        Brand = brand;
        Description = description;
        UnitOfMeasure = unitOfMeasure;
        CostPerUnit = costPerUnit;
    }
}