using Domain.Entities.Customer;
using Domain.ValueObjects;
using Infrastructure.Extensions;

namespace Business.CQRS.Customers.Handlers.Command
{
    public class CustomerBuilder
    {
        private readonly Customer _customer;

        public CustomerBuilder(Customer customer)
        {
            _customer = customer;
        }

        public CustomerBuilder AddEmail(string email) 
        {
            if (string.IsNullOrEmpty(email))
                return this;

            _customer.AddEmail(email);
            return this;
        }

        public CustomerBuilder AddMobileNumber(string mobileCountryCode, string mobileAreaCode, string mobileNumber) 
        {
            if (string.IsNullOrEmpty(mobileCountryCode) && string.IsNullOrEmpty(mobileAreaCode) && string.IsNullOrEmpty(mobileNumber))
                return this;

            _customer.AddMobileNumber(mobileCountryCode, mobileAreaCode, mobileNumber);
            return this;
        }

        public CustomerBuilder AddAddress(Address address) 
        {
            if (address.IsNull())
                return this;

            _customer.AddAddress(address);
            return this;
        }

        public TCustomer Build<TCustomer>() where TCustomer : Customer
        {
            return _customer as TCustomer;
        }
    }
}
