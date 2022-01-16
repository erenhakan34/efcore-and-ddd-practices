using Database.Context;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Api
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
                await dbContext.Database.CurrentTransaction?.RollbackAsync();
            }
        }

        private static async Task CommitTransactionAsyncIfNotNull(EFCoreDbContext dbContext)
        {
            if (dbContext.Database.CurrentTransaction != null)
            {
                await dbContext.Database.CurrentTransaction?.CommitAsync();
            }
        }
    }
}
