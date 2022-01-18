using Domain.Entities.Customer;
using Domain.ValueObjects;
using Newtonsoft.Json;

namespace Domain.Events.CustomerEvents
{
    public class CustomerAddressUpdatedEvent : DomainEvent<Customer>
    {
        public CustomerAddressUpdatedEvent(Customer entity, Address oldAddress, Address newAddress) : base(entity)
        {
            OldAddress = oldAddress;
            NewAddress = newAddress;
        }

        public Address OldAddress { get; }

        public Address NewAddress { get; }

        public override string ToString()
        {
            if (OldAddress != null)
            {
                return $"Old address={JsonConvert.SerializeObject(OldAddress)} is updated with the new address={JsonConvert.SerializeObject(NewAddress)} " +
                    $"for customer with id = { EventBody.Id}";
            }
            else 
            {
                return $"New address={JsonConvert.SerializeObject(NewAddress)} is added for customer with id = { EventBody.Id}";
            }
        }

    }
}
