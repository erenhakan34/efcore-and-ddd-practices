using Domain.Base;
using Domain.ValueObjects;
using FluentValidation;
using System;

namespace Domain.Entities.Customer
{
    public abstract class Customer : DomainEntity<int>
    {
        private readonly CustomerValidator _validator;

        public Customer(string firstName,
            string lastName,
            DateTime birthDateUtc,
            string nationalityCode)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDateUtc = birthDateUtc;
            NationalityCode = nationalityCode;

            _validator = new CustomerValidator();
            _validator.ValidateAndThrow(this);
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

        public Address Address { get; private set; }

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
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            Email = email;
            _validator.ValidateAndThrow(this);
            return this;
        }

        public Customer SetMobileNumber(string mobileCountryCode, string mobileAreaCode, string mobileNumber)
        {
            if (string.IsNullOrEmpty(mobileCountryCode))
                throw new ArgumentNullException(nameof(mobileCountryCode));

            if (string.IsNullOrEmpty(mobileAreaCode))
                throw new ArgumentNullException(nameof(mobileAreaCode));

            if (string.IsNullOrEmpty(mobileNumber))
                throw new ArgumentNullException(nameof(mobileNumber));

            MobileCountryCode = mobileCountryCode;
            MobileAreaCode = mobileAreaCode;
            MobileNumber = mobileNumber;
            _validator.ValidateAndThrow(this);
            return this;
        }

        public Customer SetAddress(Address address)
        {
            if(address == null)
                throw new ArgumentNullException(nameof(address));

            Address = address;
            _validator.ValidateAndThrow(this);
            return this;
        }
    }
}
