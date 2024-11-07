namespace Deiarts.Domain.RawMaterials;

internal interface IRawMaterialRepository
{
    void Add(RawMaterial rawMaterial);
    void Remove(RawMaterial rawMaterial);
    
    Task<RawMaterial?> GetAsync(RawMaterialId id);
}