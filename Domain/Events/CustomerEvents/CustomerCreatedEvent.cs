using Domain.Entities.Customer;

namespace Domain.Events.CustomerEvents
{
    public class CustomerCreatedEvent<TCustomer> : DomainEvent<TCustomer> where TCustomer : Customer
    {
        public CustomerCreatedEvent(TCustomer entity) : base(entity)
        {

        }

        public TCustomer Entity => EventBody;
    }
}
