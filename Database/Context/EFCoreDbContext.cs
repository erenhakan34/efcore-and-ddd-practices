using Database.Configuration;
using Domain.Base;
using Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Context
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext()
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerEntityConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is DomainEntity && (
                       e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((DomainEntity)entityEntry.Entity).CreatedDateUtc = DateTime.UtcNow;
                    ((DomainEntity)entityEntry.Entity).CreatedBy = "EFCorePractices";
                }

               ((DomainEntity)entityEntry.Entity).UpdatedDateUtc = DateTime.UtcNow;
                ((DomainEntity)entityEntry.Entity).UpdatedBy = "EFCorePractices";
            }

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
