using Domain.Entities.Customer;
using Domain.ValueObjects;

namespace Domain.Events.CustomerEvents
{
    public class CustomerAddressUpdatedEvent : DomainEvent<Customer>
    {
        public CustomerAddressUpdatedEvent(Customer entity) : base(entity)
        {

        }

        public Address Address => EventBody.Address;
    }
}
