using Domain.Base;
using FluentValidation;

namespace Domain.Entities.Product
{
    public class Product : DomainEntity<int>
    {
        private readonly ProductValidator _validator;

        public Product(string name, string imageUrl, string description, string barcode, int amount, decimal price, string currency)
        {
            Name = name;
            ImageUrl = imageUrl;
            Description = description;
            Barcode = barcode;
            Amount = amount;
            Price = price;
            Currency = currency;

            _validator = new ProductValidator();
            _validator.ValidateAndThrow(this);
        }

        public string Name { get; private set; }

        public string ImageUrl { get; private set; }

        public string Description { get; private set; }

        public string Barcode { get; private set; }

        public int Amount { get; private set; }

        public decimal Price { get; private set; }

        public string Currency { get; private set; }


        public void IncrementAmount(int value = 1) 
        {
            Amount += value;
            _validator.ValidateAndThrow(this);
        }

        public void DecrementAmount(int value = 1) 
        {
            Amount -= value;
            _validator.ValidateAndThrow(this);
        }

        public Product UpdatePrice(decimal price) 
        {
            Price = price;
            _validator.ValidateAndThrow(this);
            return this;
        }

        public Product UpdateCurrencty(string currency) 
        {
            Currency = currency;
            _validator.ValidateAndThrow(this);
            return this;
        }
    }
}
