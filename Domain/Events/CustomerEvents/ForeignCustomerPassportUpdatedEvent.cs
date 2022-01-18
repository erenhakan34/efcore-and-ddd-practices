using Domain.Entities.Customer;

namespace Domain.Events.CustomerEvents
{
    public class ForeignCustomerPassportUpdatedEvent : DomainEvent<ForeignCustomer>
    {
        public ForeignCustomerPassportUpdatedEvent(ForeignCustomer entity, string oldPassportNumber, string newPassportNumber) : base(entity)
        {
            NewPassportNumber = newPassportNumber;
            OldPassportNumber = oldPassportNumber;
        }

        public string NewPassportNumber { get; }

        public string OldPassportNumber { get; }

        public override string ToString()
        {
            return $"Old passportnumber={OldPassportNumber} is updated with the new passportnumber={NewPassportNumber} for customer with id = { EventBody.Id}";
        }
    }
}
