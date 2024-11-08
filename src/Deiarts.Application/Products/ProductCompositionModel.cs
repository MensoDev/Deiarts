using Deiarts.Domain.Products;
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Application.Products;

public class ProductCompositionModel
{
    public ProductCompositionId? Id { get; set; }

    public string Description { get; set; } = string.Empty;
    public int? Quantity { get; set; }
    
    public RawMaterialId? RawMaterialId { get; set; }


    public void CopyFrom(ProductCompositionModel model)
    {
        Id = model.Id;
        Description = model.Description;
        Quantity = model.Quantity;
        RawMaterialId = model.RawMaterialId;
    }
}