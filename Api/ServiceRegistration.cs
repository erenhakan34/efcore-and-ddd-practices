using Api.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Api
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddControllersWithOptions(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.Filters.Add(new ValidationFilter());
                config.Filters.Add(new TransactionManagerFilter());
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            return services;
        }
    }
}
