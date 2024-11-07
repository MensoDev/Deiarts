using Deiarts.Application.RawMaterials.Get;
using Deiarts.Domain.Enums;
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application.RawMaterials.Edit;

public class EditRawMaterialRequest
{
    public RawMaterialId? Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public UnitOfMeasureType? UnitOfMeasure { get; set; }
    public decimal? CostPerUnit { get; set; }

    public void CopyFrom(GetRawMaterialResponse rawMaterial)
    {
        Id = rawMaterial.Id;
        Name = rawMaterial.Name;
        Brand = rawMaterial.Brand;
        Description = rawMaterial.Description;
        UnitOfMeasure = rawMaterial.UnitOfMeasure;
        CostPerUnit = rawMaterial.CostPerUnit;
    }
}