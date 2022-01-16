using FluentValidation;
using Infrastructure.Utils;

namespace Domain.Entities.Customer
{
    public class CustomerValidator : AbstractValidator<Customer> 
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.BirthDateUtc).Must(DateTimeUtils.IsNotDefaultDate);
            RuleFor(x => x.NationalityCode).NotEmpty().MaximumLength(10);

            ValidateEmail();

            ValidateMobileNumber();

            ValidateAddress();
        }

        private void ValidateEmail()
        {
            When(r => !string.IsNullOrEmpty(r.Email), () =>
            {
                RuleFor(x => x.Email).EmailAddress().MaximumLength(50);
            });
        }

        private void ValidateMobileNumber()
        {
            When(r => !string.IsNullOrEmpty(r.MobileCountryCode) || !string.IsNullOrEmpty(r.MobileAreaCode)
                        || !string.IsNullOrEmpty(r.MobileNumber), () =>
                        {
                            RuleFor(x => x.MobileCountryCode).NotEmpty().MaximumLength(5);
                            RuleFor(x => x.MobileAreaCode).NotEmpty().MaximumLength(5);
                            RuleFor(x => x.MobileNumber).NotEmpty().MaximumLength(15);
                        });
        }

        private void ValidateAddress()
        {
            When(r => r.Address != null, () =>
            {
                RuleFor(x => x.Address.City).NotEmpty().MaximumLength(50);
                RuleFor(x => x.Address.Town).NotEmpty().MaximumLength(50);
                RuleFor(x => x.Address.Neighborhood).NotEmpty().MaximumLength(50);

                When(r => !string.IsNullOrEmpty(r.Address.Street), () =>
                {
                    RuleFor(x => x.Address.Street).MaximumLength(50);
                });

                When(r => !string.IsNullOrEmpty(r.Address.GateNumber), () =>
                {
                    RuleFor(x => x.Address.GateNumber).MaximumLength(6);
                });

                When(r => !string.IsNullOrEmpty(r.Address.ApartmentNumber), () =>
                {
                    RuleFor(x => x.Address.ApartmentNumber).MaximumLength(6);
                });
            });
        }
    }

    public class NativeCustomerValidator : AbstractValidator<NativeCustomer> 
    {
        public NativeCustomerValidator()
        {
            RuleFor(x => x.CitizenNumber).NotEmpty().Must(StringUtils.IsNumeric)
                .Must(StringUtils.IsValidCitizenNumber).MaximumLength(11);
        }
    }

    public class ForeignCustomerValidator : AbstractValidator<ForeignCustomer> 
    {
        public ForeignCustomerValidator()
        {
            RuleFor(x => x.PassportNumber).NotEmpty().MaximumLength(10);
        }
    }
}
