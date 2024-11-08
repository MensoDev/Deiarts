namespace Deiarts.Domain.Products;

internal interface IProductRepository
{
    void Add(Product product);
    void Remove(Product product);
    Task<Product?> GetAsync(ProductId id);
}