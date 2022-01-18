using Business.CQRS.Customers.Commands;
using Business.CQRS.Customers.DTOs;
using Database.Context;
using Database.Repositories;
using Domain.Ports;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Newtonsoft;
using System.Text.Json.Serialization;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFCoreDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration.GetConnectionString("Default"), sqlOptions =>
                {
                    sqlOptions.CommandTimeout(10);
                });
            });

            services.AddScoped<IReadRepository<int>, ReadRepository<int>>();
            services.AddScoped<IWriteRepository<int>, WriteRepository<int>>();

            services.AddMediatR(typeof(CreateNativeCustomerCommand));

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetAssembly(typeof(CustomerResultDTO)));

            services.AddControllers(config =>
            {
                config.Filters.Add(new TransactionManagerFilter());
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
