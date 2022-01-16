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
    public class WriteRepository<TId> : IWriteRepository<TId> where TId : struct
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
        public async Task<int> AddAsync<TEntity>(TEntity entity, bool saveChanges = false) where TEntity : DomainEntity<TId>
        {
            int result = 0;
            entity.SetCreatedAudit();
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
        public async Task<int> AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool saveChanges = false) where TEntity : DomainEntity<TId>
        {
            int result = 0;
            entities.ToList().ForEach(e => e.SetCreatedAudit());
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
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : DomainEntity<TId>
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

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
        /// Remove entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="softDelete"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        public async Task RemoveAsync<TEntity>(TEntity entity, bool softDelete = true, bool saveChanges = false) where TEntity : DomainEntity<TId>
        {
            if (softDelete)
            {
                entity.SetDeleted();
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Remove a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="softDelete"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool softDelete = true, bool saveChanges = false) where TEntity : DomainEntity<TId>
        {
            if (softDelete)
            {
                entities.ToList().ForEach(e => e.SetDeleted());
                _dbContext.Entry(entities).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Set<TEntity>().RemoveRange(entities);
            }

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
        public async Task UpdateAsync<TEntity>(TEntity entity, bool saveChanges = false) where TEntity : DomainEntity<TId>
        {
            entity.SetUpdatedAudit();
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
        public async Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool saveChanges = false) where TEntity : DomainEntity<TId>
        {
            entities.ToList().ForEach(e => e.SetUpdatedAudit());
            _dbContext.Set<TEntity>().UpdateRange(entities);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
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
    }
}
