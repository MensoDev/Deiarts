using Deiarts.Application.Products;
using Deiarts.Application.Products.Get;
using Deiarts.Application.Products.List;

namespace Deiarts.Infrastructure.Queries;

internal class ProductQueries(DeiartsDbContext db) : IProductQueries
{
    public async Task<ListProductsResponseItem[]> ListAsync(string? term)
    {
        var query = db.Products
            .AsNoTracking();

        if (term.IsNotNullOrWhiteSpace())
        {
            query = query.Where(product => product.Name.Contains(term));
        }

        return await query
            .Select(p => new ListProductsResponseItem
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CompositionsCount = p.Compositions.Count
            })
            .ToArrayAsync();
    }

    public Task<GetProductResponse?> GetAsync(ProductId productId)
    {
        return db.Products
            .AsNoTracking()
            .Where(p => p.Id == productId)
            .Select(p => new GetProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Compositions = p.Compositions.Select(c => new ProductCompositionModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    Quantity = c.Quantity,
                    RawMaterialId = c.RawMaterialId
                }).ToArray()
            })
            .SingleOrDefaultAsync();
    }
}