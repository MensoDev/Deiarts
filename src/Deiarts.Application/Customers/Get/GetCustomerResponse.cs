namespace Deiarts.Application.Customers.Get;

public class GetCustomerResponse
{
    public required CustomerId Id { get; init; }
    public required string Name { get; init; }
    public required string Phone { get; init; }
    public required string Email { get; init; }
}