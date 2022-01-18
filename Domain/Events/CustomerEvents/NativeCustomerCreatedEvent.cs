using Domain.Entities.Customer;

namespace Domain.Events.CustomerEvents
{
    public class NativeCustomerCreatedEvent : DomainEvent<NativeCustomer> 
    {
        public NativeCustomerCreatedEvent(NativeCustomer entity) : base(entity)
        {

        }

        public NativeCustomer Entity => EventBody;

        public override string ToString()
        {
            return $"Native customer is created with citizen number = {EventBody.CitizenNumber}";
        }
    }
}
