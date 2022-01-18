using Domain.Events.CustomerEvents;
using FluentValidation;
using System;

namespace Domain.Entities.Customer
{
    public class ForeignCustomer : Customer
    {
        private readonly ForeignCustomerValidator _validator;

        public ForeignCustomer(string passportNumber,
            string firstName,
            string lastName,
            DateTime birthDateUtc,
            string nationalityCode) : base(firstName, lastName, birthDateUtc, nationalityCode)
        {
            PassportNumber = passportNumber;

            _validator = new ForeignCustomerValidator();
            _validator.ValidateAndThrow(this);

            AddEvent(new CustomerCreatedEvent<ForeignCustomer>(this));
        }

        public string PassportNumber { get; private set; }

        public void UpdatePassportNumber(string passportNumber) 
        {
            if (string.IsNullOrEmpty(passportNumber))
                throw new ArgumentNullException(nameof(passportNumber));

            AddEvent(new ForeignCustomerPassportUpdatedEvent(this, PassportNumber, passportNumber));

            PassportNumber = passportNumber;
            _validator.ValidateAndThrow(this);
        }
    }
}
