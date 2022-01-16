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

        public Customer AddEmail(string email) 
        {
            //Validate input

            if (IsEmailSetBefore()) 
            {
                throw new InvalidOperationException("Email is already set");
            }

            Email = email;
            return this;
        }

        public Customer AddMobileNumber(string mobileCountryCode, string mobileAreaCode, string mobileNumber) 
        {
            //Validate input

            if (IsMobileNumberSetBefore()) 
            {
                throw new InvalidOperationException("Mobile number is already set");
            }

            MobileCountryCode = mobileCountryCode;
            MobileAreaCode = mobileAreaCode;
            MobileNumber = mobileNumber;

            return this;
        }


        public Customer UpdateEmail(string email)
        {
            //Validate inout

            if (!IsEmailSetBefore())
            {
                throw new InvalidOperationException("Email has to be set first");
            }

            Email = email;
            return this;
        }

        public Customer UpdateMobileNumber(string mobileCountryCode, string mobileAreaCode, string mobileNumber) 
        {
            //Validate input

            if (!IsMobileNumberSetBefore()) 
            {
                throw new InvalidOperationException("Mobile number has to be set first");
            }

            MobileCountryCode = mobileCountryCode;
            MobileAreaCode = mobileAreaCode;
            MobileNumber = mobileNumber;
            return this;
        }

        private bool IsMobileNumberSetBefore() 
        {
            return !string.IsNullOrEmpty(MobileCountryCode) 
                && !string.IsNullOrEmpty(MobileAreaCode)
                && !string.IsNullOrEmpty(MobileNumber);
        }

        private bool IsEmailSetBefore() 
        {
            return !string.IsNullOrEmpty(Email);
        }
    }
}
