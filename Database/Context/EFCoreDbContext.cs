using Database.Configuration;
using Domain.Entities.Customer;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
        {
            Database.AutoTransactionsEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<NativeCustomer> NativeCustomers { get; set; }
        public DbSet<ForeignCustomer> ForeignCustomers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerEntityConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
