using Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Domain.Specifications
{
    public static class CustomerSpecifications
    {
        public static IQueryable<Customer> OrderByEmailDesc(this IQueryable<Customer> customerQuery)
        {
            return customerQuery
                .OrderByDescending(c => c.Email);
        }

        public static IQueryable<Customer> OrderByCityAsc(this IQueryable<Customer> customerQuery)
        {
            return customerQuery
                .Include(c => c.Address)
                .OrderBy(c => c.Address.City);
        }
    }
}
