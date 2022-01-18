using Domain.Entities.Customer;

namespace Domain.Events.CustomerEvents
{
    public class CustomerEmailUpdatedEvent : DomainEvent<Customer>
    {
        public CustomerEmailUpdatedEvent(Customer entity, string oldEmail, string newEmail) : base(entity)
        {
            OldEmail = oldEmail;
            NewEmail = newEmail;
        }

        public string OldEmail { get; }
        public string NewEmail { get; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(OldEmail))
            {
                return $"Old email={OldEmail} is updated with the new email={NewEmail} for customer with id = { EventBody.Id}";
            }
            else
            {
                return $"New email={NewEmail} is added for customer with id = { EventBody.Id}";
            }
        }
    }
}
