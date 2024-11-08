namespace Deiarts.Application.Customers.List;

public class ListCustomersResponseItem
{
    public required CustomerId Id { get; init; }
    public required string Name { get; init; }
    public required string Phone { get; init; }
    public required string Email { get; init; }
}