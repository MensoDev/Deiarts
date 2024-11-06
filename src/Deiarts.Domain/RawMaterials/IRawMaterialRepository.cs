namespace Deiarts.Domain.RawMaterials;

public interface IRawMaterialRepository
{
    void Add(RawMaterial rawMaterial);
    
    Task<RawMaterial?> GetAsync(RawMaterialId id);
}