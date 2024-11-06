using Cblx.Blocks;
using Deiarts.Common.Domain.Entities;

namespace Deiarts.Domain.RawMaterials;

[StronglyTypedId] public readonly partial struct RawMaterialId;

[HasPrivateEmptyConstructor]
public partial class RawMaterial : Entity<RawMaterialId>, IAggregateRoot
{
    public RawMaterial(string name, string description)
    {
        Name = name;
        Description = description;
    }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }
}