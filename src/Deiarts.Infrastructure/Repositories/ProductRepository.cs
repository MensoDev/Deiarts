using Deiarts.Domain.Products;

namespace Deiarts.Infrastructure.Repositories;

internal class ProductRepository(DeiartsDbContext db) : BaseRepository<Product, ProductId>(db), IProductRepository;