using Deiarts.Domain.Customers;

namespace Deiarts.Infrastructure.Repositories;

internal class CustomerRepository(DeiartsDbContext db) : BaseRepository<Customer, CustomerId>(db), ICustomerRepository;