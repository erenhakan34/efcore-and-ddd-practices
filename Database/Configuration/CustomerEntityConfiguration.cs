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

            customer.HasIndex(c => c.Id)
                .IsClustered()
                .IsUnique();

            customer.Property(x => x.Id)              
                 .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            customer.Property(x => x.FirstName)
                .HasMaxLength(50);

            customer.Property(x => x.LastName)
                .HasMaxLength(50);

            customer.Property(x => x.NationalityCode)
                .HasMaxLength(10);

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
}
