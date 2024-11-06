using Cblx.Blocks;

namespace Deiarts.Domain.RawMaterials;

[StronglyTypedId] public readonly partial struct RawMaterialId;

[HasPrivateEmptyConstructor]
public partial class RawMaterial
{
    public RawMaterial(string name, string description)
    {
        Name = name;
        Description = description;
    }
    
    public RawMaterialId Id { get; private set; }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
}