namespace Deiarts.Domain.Customers;

internal interface ICustomerRepository
{
    void Add(Customer customer);
    void Remove(Customer customer);
    Task<Customer?> GetAsync(CustomerId id);
}