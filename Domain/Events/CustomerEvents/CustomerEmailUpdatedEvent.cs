using Domain.Entities.Customer;

namespace Domain.Events.CustomerEvents
{
    public class CustomerEmailUpdatedEvent : DomainEvent<Customer>
    {
        public CustomerEmailUpdatedEvent(Customer entity) : base(entity)
        {

        }

        public string Email =>  EventBody.Email;
    }
}
