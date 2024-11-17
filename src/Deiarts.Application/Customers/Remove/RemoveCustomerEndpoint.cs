using Deiarts.Domain.Customers;

namespace Deiarts.Application.Customers.Remove;

public class RemoveCustomerEndpoint() : CommandEndpoint<ValueRequest<CustomerId>>(
    Default.ValueRequestCustomerId,
    allowAnonymous: true)
{
    internal static async Task ExecuteAsync(ValueRequest<CustomerId> request, ICustomerRepository repository, IUnitOfWork unitOfWork)
    {
        var customer = await repository.GetAsync(request);
        Throw.Http.NotFound.When.Null(customer, "Cliente não encontrado.");
        
        // TODO: válidar se o cliente tem orçamentos para ele
        
        repository.Remove(customer);
        await unitOfWork.SaveChangesAsync();
    }
}