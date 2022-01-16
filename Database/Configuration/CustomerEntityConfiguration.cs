using Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configuration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customer)
        {
            customer.ToTable("Customers");

            customer.Property(x => x.Id)              
                 .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            customer.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            customer.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            customer.Property(x => x.NationalityCode)
                .HasMaxLength(10)
                .IsRequired();

            customer.Property(x => x.Email)
                .HasMaxLength(50);

            customer.Property(x => x.MobileCountryCode)
                .HasMaxLength(5);

            customer.Property(x => x.MobileAreaCode)
                .HasMaxLength(5);

            customer.Property(x => x.MobileNumber)
                .HasMaxLength(15);

            customer.Ignore(c => c.FullName);
            customer.Ignore(c => c.Age);
        }
    }

    public class NativeCustomerEntityConfiguration : IEntityTypeConfiguration<NativeCustomer> 
    {
        public void Configure(EntityTypeBuilder<NativeCustomer> nativeCustomer) 
        {
            nativeCustomer.Property(n => n.CitizenNumber)
                .HasMaxLength(11);
        }
    }

    public class ForeignCustomerEntityConfiguration : IEntityTypeConfiguration<ForeignCustomer>
    {
        public void Configure(EntityTypeBuilder<ForeignCustomer> foreignCustomer)
        {
            foreignCustomer.Property(n => n.PassportNumber)
                .HasMaxLength(10);
        }
    }
}
