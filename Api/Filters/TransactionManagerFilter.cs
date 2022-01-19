using Database.Context;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Api.Filters
{
    public class TransactionManagerFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionExecutedContext = await next();

            var dbContext = (EFCoreDbContext)actionExecutedContext.HttpContext.RequestServices.GetService(typeof(EFCoreDbContext));

            if (actionExecutedContext.Exception == null)
            {
                await dbContext.SaveChangesAsync();

                await CommitTransactionAsyncIfNotNull(dbContext);
            }
            else 
            {
                await RollbackTransactionAsyncIfNotNull(dbContext);
            }
        }

        private static async Task CommitTransactionAsyncIfNotNull(EFCoreDbContext dbContext)
        {
            if (dbContext.Database.CurrentTransaction != null)
            {
                await dbContext.Database.CurrentTransaction?.CommitAsync();
            }
        }

        private static async Task RollbackTransactionAsyncIfNotNull(EFCoreDbContext dbContext)
        {
            if (dbContext.Database.CurrentTransaction != null)
            {
                await dbContext.Database.CurrentTransaction?.RollbackAsync();
            }
        }
    }
}
