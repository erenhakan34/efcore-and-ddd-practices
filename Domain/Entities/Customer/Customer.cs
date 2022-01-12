using Domain.Base;
using System;

namespace Domain.Entities.Customer
{
    public abstract class Customer : Entity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string MobileCountryCode { get; set; }

        public string MobileAreaCode { get; set; }

        public string MobileNumber { get; set; }

        public string NationalityCode { get; set; }

        public int Age
        {
            get
            {
                DateTime nowDate = DateTime.Now;

                int age = nowDate.Year - BirthDate.Year;

                if (nowDate.Month < BirthDate.Month || (nowDate.Month == BirthDate.Month && nowDate.Day < BirthDate.Day))
                    age--;

                return age;
            }
        }
    }
}
