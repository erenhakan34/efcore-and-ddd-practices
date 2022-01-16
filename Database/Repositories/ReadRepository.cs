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
    public class ReadRepository<TId> : IReadRepository<TId> where TId : struct
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
        public IQueryable<TEntity> Get<TEntity>(TId id) where TEntity : DomainEntity<TId>
        {
            return GetAll<TEntity>().Where(e => e.Id.Equals(id));
        }

        /// <summary>
        /// Get entity by custom expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : DomainEntity<TId>
        {
            return GetAll<TEntity>().Where(expression);
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : DomainEntity<TId>
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        /// <summary>
        /// Check entity if exists
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : DomainEntity<TId>
        {
            return await _dbContext.Set<TEntity>().AnyAsync(expression);
        }

        /// <summary>
        /// Get counts of entity by giving criteria
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : DomainEntity<TId>
        {
            return await _dbContext.Set<TEntity>().CountAsync(expression);
        }

        #endregion
    }
}
