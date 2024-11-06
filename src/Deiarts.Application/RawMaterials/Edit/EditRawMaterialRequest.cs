using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application.RawMaterials.Edit;

public class EditRawMaterialRequest
{
    public RawMaterialId? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}