using Deiarts.Application.Customers.Get;

namespace Deiarts.Application.Customers.Edit;

public class EditCustomerRequest
{
    public CustomerId? Id { get; set; }
    
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public void CopyFrom(GetCustomerResponse customer)
    {
        Id = customer.Id;
        Name = customer.Name;
        Phone = customer.Phone;
        Email = customer.Email;
    }
}