using Domain.Entities.Customer;

namespace Domain.Events.CustomerEvents
{
    public class ForeignCustomerPassportUpdatedEvent : DomainEvent<ForeignCustomer>
    {
        public ForeignCustomerPassportUpdatedEvent(ForeignCustomer entity) : base(entity)
        {

        }

        public string PassportNumber => EventBody.PassportNumber;

    }
}
