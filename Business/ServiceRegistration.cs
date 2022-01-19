using Business.CQRS.Customers.Commands;
using Business.CQRS.Customers.DTOs;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateNativeCustomerCommand));
            return services;
        }

        public static IServiceCollection AddMapster(this IServiceCollection services) 
        {
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetAssembly(typeof(CustomerResultDTO)));
            return services;
        }
    }
}
