using FluentValidation;
using Infrastructure.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private const string DefaultContentType = "application/json";

        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ValidationException validationEx)
            {
                httpContext.Response.ContentType = DefaultContentType;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var exceptionBody = JsonConvert.SerializeObject(validationEx.Errors);
                await httpContext.Response.WriteAsync(exceptionBody);
            }
            catch
            {
                httpContext.Response.ContentType = DefaultContentType;
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var exceptionBody = JsonConvert.SerializeObject(new Error { Code = "Unidentified", Message = "Şu anda işleminizi gerçekleştiremiyoruz." });
                await httpContext.Response.WriteAsync(exceptionBody);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
