using Database.Configuration;
using Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext()
        {
            Database.AutoTransactionsEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerEntityConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
