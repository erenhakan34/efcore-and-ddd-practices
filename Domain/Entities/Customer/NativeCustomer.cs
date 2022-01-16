using System;

namespace Domain.Entities.Customer
{
    public class NativeCustomer : Customer
    {
        public NativeCustomer(string citizenNumber, 
            string firstName,
            string lastName,
            DateTime birthDateUtc,
            string nationalityCode) : base(firstName, lastName, birthDateUtc, nationalityCode)
        {
            CitizenNumber = citizenNumber;
        }

        public string CitizenNumber { get; private set; }
    }
}
