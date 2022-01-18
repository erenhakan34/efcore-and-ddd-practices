using Domain.Events.CustomerEvents;
using FluentValidation;
using System;

namespace Domain.Entities.Customer
{
    public class NativeCustomer : Customer
    {
        private readonly NativeCustomerValidator _validator;
        public NativeCustomer(string citizenNumber, 
            string firstName,
            string lastName,
            DateTime birthDateUtc,
            string nationalityCode) : base(firstName, lastName, birthDateUtc, nationalityCode)
        {
            CitizenNumber = citizenNumber;

            _validator = new NativeCustomerValidator();
            _validator.ValidateAndThrow(this);

            AddEvent(new CustomerCreatedEvent<NativeCustomer>(this));
        }

        public string CitizenNumber { get; private set; }
    }
}
