namespace Deiarts.Domain.Customers;

[HasPrivateEmptyConstructor]
internal partial class ContactVo
{
    public ContactVo(string phone, string email)
    {
        Phone = phone;
        Email = email;
    }

    public string Phone { get; private set; }
    public string Email { get; private set; }
}