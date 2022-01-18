using Domain.ValueObjects;
using MediatR;
using System;

namespace Business.CQRS.Customers.Commands
{
    public class CreateNativeCustomerCommand : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalityCode { get; set; }

        public DateTime BirthDateUtc { get; set; }

        public string CitizenNumber { get; set; }

        public string Email { get; set; }

        public string MobileCountryCode { get; set; }

        public string MobileAreaCode { get; set; }

        public string MobileNumber { get; set; }

        public Address Address { get; set; }
    }
}
