using Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System;
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

        public static IQueryable<Customer> GetCustomersLivingIn(this IQueryable<Customer> customerQuery, string city) 
        {
            return customerQuery
                .Include(c => c.Address)
                .Where(c => c.Address.City.Equals(city));
        }

        public static IQueryable<Customer> GetCustomersGreaterThanAge(this IQueryable<Customer> customerQuery, int age) 
        {
            DateTime date = DateTime.UtcNow.AddYears(-age);

            return customerQuery.Where(c => c.BirthDateUtc.Year < date.Year);
        }

        public static IQueryable<Customer> GetCustomersLessThanAge(this IQueryable<Customer> customerQuery, int age)
        {
            DateTime date = DateTime.UtcNow.AddYears(-age);

            return customerQuery.Where(c => c.BirthDateUtc.Year > date.Year);
        }
    }
}
