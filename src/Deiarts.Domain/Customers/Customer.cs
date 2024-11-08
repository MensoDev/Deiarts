namespace Deiarts.Domain.Customers;

[HasPrivateEmptyConstructor]
internal partial class Customer : Entity<CustomerId>, IAggregateRoot
{
    public Customer(string name, ContactVo contact)
    {
        Name = name;
        Contact = contact;
    }

    public string Name { get; private set; }
    public ContactVo Contact { get; private set; }

    public void Update(string name, ContactVo contact)
    {
        Name = name;
        Contact = contact;
    }
}