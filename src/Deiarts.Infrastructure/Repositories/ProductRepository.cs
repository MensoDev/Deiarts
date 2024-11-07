using Deiarts.Domain.Products;
using Deiarts.Infrastructure.DbContexts;

namespace Deiarts.Infrastructure.Repositories;

internal class ProductRepository(DeiartsDbContext db) : BaseRepository<Product, ProductId>(db), IProductRepository;