using Domain.Base;
using System;

namespace Domain.Entities.Customer
{
    public abstract class Customer : DomainEntity<int>
    {

        public Customer(string firstName,
            string lastName,
            DateTime birthDateUtc,
            string nationalityCode)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDateUtc = birthDateUtc;
            NationalityCode = nationalityCode;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FullName { get; }

        public DateTime BirthDateUtc { get; private set; }

        public string Email { get; private set; }

        public string MobileCountryCode { get; private set; }

        public string MobileAreaCode { get; private set; }

        public string MobileNumber { get; private set; }

        public string NationalityCode { get; private set; }

        public int Age
        {
            get
            {
                DateTime nowDateUtc = DateTime.UtcNow;

                int age = nowDateUtc.Year - BirthDateUtc.Year;

                if (nowDateUtc.Month < BirthDateUtc.Month || (nowDateUtc.Month == BirthDateUtc.Month && nowDateUtc.Day < BirthDateUtc.Day))
                    age--;

                return age;
            }
        }

        public Customer SetEmail(string email) 
        {
            //Validate input

            Email = email;
            return this;
        }

        public Customer SetMobileNumber(string mobileCountryCode, string mobileAreaCode, string mobileNumber) 
        {
            //Validate input

            MobileCountryCode = mobileCountryCode;
            MobileAreaCode = mobileAreaCode;
            MobileNumber = mobileNumber;

            return this;
        }
    }
}
