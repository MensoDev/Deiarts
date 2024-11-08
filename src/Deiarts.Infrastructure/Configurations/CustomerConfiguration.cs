using Deiarts.Domain.Customers;

namespace Deiarts.Infrastructure.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Table

        builder.HasKey(customer => customer.Id);
        builder.Property(customer => customer.Id).ValueGeneratedOnAdd();
        
        // Properties
        
        builder.Property(customer => customer.Name).IsRequired().HasMaxLength(200);
        
        // Value Objects
        
        builder.OwnsOne(customer => customer.Contact, contactBuilder =>
        {
            contactBuilder.Property(contact => contact.Email).IsRequired().HasMaxLength(200);
            contactBuilder.Property(contact => contact.Phone).IsRequired().HasMaxLength(20);
        });
    }
}