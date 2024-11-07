using Deiarts.Domain.Products;
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application.Products.Edit;

public class EditProductCompositionDto
{
    public ProductCompositionId? Id { get; set; }

    public string Description { get; set; } = string.Empty;
    public int? Quantity { get; set; }
    public RawMaterialId? RawMaterialId { get; set; }
}