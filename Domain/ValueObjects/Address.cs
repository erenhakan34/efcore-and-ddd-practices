using Domain.Base;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string City { get; set; }
        public string Town { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string GateNumber { get; set; }
        public string ApartmentNumber { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Town;
            yield return Neighborhood;
            yield return Street;
            yield return GateNumber;
            yield return ApartmentNumber;
        }
    }
}
