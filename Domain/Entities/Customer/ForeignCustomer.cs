using System;

namespace Domain.Entities.Customer
{
    public class ForeignCustomer : Customer
    {
        public ForeignCustomer(string passportNumber,
            string firstName,
            string lastName,
            DateTime birthDateUtc,
            string nationalityCode) : base(firstName, lastName, birthDateUtc, nationalityCode)
        {
            PassportNumber = passportNumber;
        }

        public string PassportNumber { get; private set; }

        public void UpdatePassportNumber(string passportNumber) 
        {
            //Validate input

            PassportNumber = passportNumber;
        }
    }
}
