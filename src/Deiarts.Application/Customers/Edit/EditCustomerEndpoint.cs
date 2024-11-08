using Deiarts.Domain.Customers;

namespace Deiarts.Application.Customers.Edit;

public class EditCustomerEndpoint() : CommandEndpoint<EditCustomerRequest>(
    Default.EditCustomerRequest,
    validator: new EditCustomerValidator(),
    allowAnonymous: true)
{
    internal static async Task ExecuteAsync(
        EditCustomerRequest request, 
        ICustomerRepository repository,
        IUnitOfWork unitOfWork)
    {
        Customer customer;
        var contact = new ContactVo(request.Phone!, request.Email!);
        
        if (request.Id.HasValue)
        {
            var customerFound = await repository.GetAsync(request.Id.Value);
            Throw.Http.NotFound.When.Null(customerFound, "Cliente não encontrado.");
            customer = customerFound;
            customer.Update(request.Name!, contact);
        }
        else
        {
            customer = new Customer(request.Name!, contact);
            repository.Add(customer);
        }

        await unitOfWork.SaveChangesAsync();
    }
}