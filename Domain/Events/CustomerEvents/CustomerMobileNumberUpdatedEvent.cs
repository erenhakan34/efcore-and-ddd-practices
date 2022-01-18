using Domain.Entities.Customer;

namespace Domain.Events.CustomerEvents
{
    public class CustomerMobileNumberUpdatedEvent : DomainEvent<Customer>
    {
        public CustomerMobileNumberUpdatedEvent(Customer entity, string oldMobileNumber, string newMobileNumber) : base(entity)
        {
            OldMobileNumber = oldMobileNumber;
            NewMobileNumber = newMobileNumber;
        }

        public string OldMobileNumber { get; }
        public string NewMobileNumber { get; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(OldMobileNumber))
            {
                return $"Old mobilenumber={OldMobileNumber} is updated with the new mobilenumber={NewMobileNumber} for customer with id = { EventBody.Id}";
            }
            else 
            {
                return $"Mobilenumber={NewMobileNumber} is added for customer with id = { EventBody.Id}";
            }
        }
    }
}
