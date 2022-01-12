using Domain.Base;
using System;

namespace Domain.Entities.Customer
{
    public abstract class Customer : DomainEntity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; }

        public DateTime BirthDateUtc { get; set; }

        public string Email { get; set; }

        public string MobileCountryCode { get; set; }

        public string MobileAreaCode { get; set; }

        public string MobileNumber { get; set; }

        public string NationalityCode { get; set; }

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
    }
}
