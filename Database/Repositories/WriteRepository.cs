using Database.Context;
using Domain.Base;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : DomainEntity<int>
    {
        #region Readonly fields 

        private readonly EFCoreDbContext _dbContext;

        #endregion

        #region Constructors 

        public WriteRepository(EFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods 

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Number of added entities</returns>
        public async Task<int> AddAsync(TEntity entity, bool saveChanges = false)
        {
            int result = 0;
            await _dbContext.Set<TEntity>().AddAsync(entity);

            if (saveChanges)
            {
                result = await _dbContext.SaveChangesAsync();
            }

            return result;
        }

        /// <summary>
        /// Add a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>Number of added entities</returns>
        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = false)
        {
            int result = 0;
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);

            if (saveChanges)
            {
                result = await _dbContext.SaveChangesAsync();
            }

            return result;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetQueryableEntity().ToListAsync();
        }

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
        /// Remove entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task RemoveAsync(TEntity entity, bool saveChanges = false)
        {
            _dbContext.Set<TEntity>().Remove(entity);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Remove a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = false)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TEntity entity, bool saveChanges = false)
        {
            _dbContext.Set<TEntity>().Update(entity);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Update a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = false)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Begin new transaction with specified isolation level
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public async Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (_dbContext.Database.CurrentTransaction == null)
            {
                await _dbContext.Database.BeginTransactionAsync(isolationLevel);
            }
        }


        /// <summary>
        /// Commit current transaction
        /// </summary>
        /// <returns></returns>
        public async Task CommitTransactionAsync()
        {
            if (_dbContext.Database.CurrentTransaction != null)
            {
                await _dbContext.SaveChangesAsync();
                await _dbContext.Database.CurrentTransaction.CommitAsync();
            }
        }

        /// <summary>
        /// Rollback current transaction
        /// </summary>
        /// <returns></returns>
        public async Task RollbackTransactionAsync()
        {
            if (_dbContext.Database.CurrentTransaction != null)
            {
                await _dbContext.Database.CurrentTransaction.RollbackAsync();
            }
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
