using Domain.Entities.Customer;
using Domain.ValueObjects;
using Mapster;
using System;

namespace Business.CQRS.Customers.DTOs
{
    public class CustomerResultDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDateUtc { get; set; }

        public string Email { get; set; }

        public string MobileCountryCode { get; set; }

        public string MobileAreaCode { get; set; }

        public string MobileNumber { get; set; }

        public string NationalityCode { get; set; }

        public string CitizenNumber { get; set; }

        public string PassportNumber { get; set; }

        public Address Address { get; set; }

        public int Age { get; set; }
    }

    public class CustomerResultDTOCustomMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<Customer, CustomerResultDTO>()
                .Map(dest => dest.PassportNumber, src => ((ForeignCustomer)src).PassportNumber, src => src is ForeignCustomer)
                .Map(dest => dest.CitizenNumber, src => ((NativeCustomer)src).CitizenNumber, src => src is NativeCustomer)
                .Map(dest => dest.Address, src => src.Address);
        }
    }
}
