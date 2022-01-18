using Domain.Entities.Customer;

namespace Domain.Events.CustomerEvents
{
    public class ForeignCustomerCreatedEvent : DomainEvent<ForeignCustomer> 
    {
        public ForeignCustomerCreatedEvent(ForeignCustomer entity) : base(entity)
        {

        }

        public ForeignCustomer Entity => EventBody;

        public override string ToString()
        {
            return $"Foreign customer is created with passport number = {EventBody.PassportNumber}";
        }
    }
}
