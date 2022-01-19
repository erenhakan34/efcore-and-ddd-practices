using FluentValidation;

namespace Domain.Entities.Product
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Barcode).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Amount).Must(amount => amount > 0);
            RuleFor(x => x.Price).Must(price => price > 0);
            RuleFor(x => x.Currency).NotEmpty().MaximumLength(3);
        }
    }
}
