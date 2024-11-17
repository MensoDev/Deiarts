using Deiarts.Application;


namespace Deiarts.Infrastructure.Services;

internal class PricingService(DeiartsDbContext db) : IPricingService
{
    public async Task<decimal> CalculatePriceAsync(ProductId productId, int quantity)
    {
        var product = await db.Products.FindAsync(productId);
        Throw.When.Null(product, "Produto não encontrado.");

        var rawMaterialIds = product.Compositions.Select(composition => composition.RawMaterialId).ToArray();
        
        var rawMaterials = await db
            .RawMaterials
            .Where(rawMaterial => rawMaterialIds.Contains(rawMaterial.Id))
            .ToArrayAsync();
        
        var rawMaterialsCost = rawMaterials.Sum(rawMaterial => rawMaterial.CostPerUnit);
        
        return rawMaterialsCost * quantity;
    }
}