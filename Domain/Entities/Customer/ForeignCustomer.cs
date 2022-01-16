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
        }

        public string PassportNumber { get; private set; }

        public void UpdatePassportNumber(string passportNumber) 
        {
            if (string.IsNullOrEmpty(passportNumber))
                throw new ArgumentNullException(nameof(passportNumber));


            PassportNumber = passportNumber;
            _validator.ValidateAndThrow(this);
        }
    }
}
