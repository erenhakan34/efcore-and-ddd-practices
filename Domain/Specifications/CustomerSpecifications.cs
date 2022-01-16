using Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Domain.Specifications
{
    public static class CustomerSpecifications
    {
        public static IQueryable<TEntity> OrderByEmailDesc<TEntity>(this IQueryable<Customer> customerQuery) where TEntity : Customer
        {
            return customerQuery
                .OrderByDescending(c => c.Email).AsQueryable() as IQueryable<TEntity>;
        }

        public static IQueryable<TEntity> OrderByCityAsc<TEntity>(this IQueryable<Customer> customerQuery) where TEntity : Customer
        {
            return customerQuery
                .Include(c => c.Address)
                .OrderBy(c => c.Address.City).AsQueryable() as IQueryable<TEntity>;
        }
    }
}
