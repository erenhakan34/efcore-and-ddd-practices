using Database.Context;
using Domain.Base;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : DomainEntity<int>
    {
        #region Readonly fields 

        private readonly EFCoreDbContext _dbContext;

        #endregion

        #region Constructors 

        public ReadRepository(EFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods 

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(int id)
        {
            return await GetQueryableEntity().FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Get entity by custom expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await GetQueryableEntity().FirstOrDefaultAsync(expression);
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetQueryableEntity().ToListAsync();
        }

        #endregion

        #region Private Methods 

        private IQueryable<TEntity> GetQueryableEntity()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        #endregion
    }
}
