using Database.Context;
using Database.Repositories;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    public static class ServiceRegistration
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddDbContext<EFCoreDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("Default"), sqlOptions =>
                {
                    sqlOptions.CommandTimeout(10);
                });
            });

            services.AddScoped<IReadRepository<int>, ReadRepository<int>>();
            services.AddScoped<IWriteRepository<int>, WriteRepository<int>>();
        }
    }
}
