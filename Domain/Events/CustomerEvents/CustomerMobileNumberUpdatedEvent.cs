using Domain.Entities.Customer;

namespace Domain.Events.CustomerEvents
{
    public class CustomerMobileNumberUpdatedEvent : DomainEvent<Customer>
    {
        public CustomerMobileNumberUpdatedEvent(Customer entity) : base(entity)
        {

        }

        public string MobileCountryCode => EventBody.MobileCountryCode;
        public string MobileAreaCode => EventBody.MobileAreaCode;
        public string MobileNumber => EventBody.MobileNumber;
    }
}
