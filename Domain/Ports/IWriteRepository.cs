using Domain.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IWriteRepository<TId> : IReadRepository<TId> where TId : struct
    {
        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges"></param>
        /// <returns>Number of added entities</returns>
        Task<int> AddAsync<TEntity>(TEntity entity, bool saveChanges = false) where TEntity : DomainEntity<TId>;

        /// <summary>
        /// Add a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChanges"></param>
        /// <returns>Number of added entities</returns>
        Task<int> AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool saveChanges = false) where TEntity : DomainEntity<TId>;

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task UpdateAsync<TEntity>(TEntity entity, bool saveChanges = false) where TEntity : DomainEntity<TId>;

        /// <summary>
        /// Update a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool saveChanges = false) where TEntity : DomainEntity<TId>;

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="softDelete"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task RemoveAsync<TEntity>(TEntity entity, bool softDelete = true, bool saveChanges = false) where TEntity : DomainEntity<TId>;

        /// <summary>
        /// Remove a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="softDelete"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entities, bool softDelete = true, bool saveChanges = false) where TEntity : DomainEntity<TId>;

        /// <summary>
        /// Begin new transaction with specified isolation level
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Commit current transaction
        /// </summary>
        /// <returns></returns>
        Task CommitTransactionAsync();

        /// <summary>
        /// Rollback current transaction
        /// </summary>
        /// <returns></returns>
        Task RollbackTransactionAsync();
    }
}
