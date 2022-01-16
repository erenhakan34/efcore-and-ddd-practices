using Domain.Base;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IWriteRepository<TEntity> : IReadRepository<TEntity> where TEntity : DomainEntity<int>
    {
        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges"></param>
        /// <returns>Number of added entities</returns>
        Task<int> AddAsync(TEntity entity, bool saveChanges = false);

        /// <summary>
        /// Add a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChanges"></param>
        /// <returns>Number of added entities</returns>
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = false);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity, bool saveChanges = false);

        /// <summary>
        /// Update a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, bool saveChanges = false);

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="softDelete"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task RemoveAsync(TEntity entity, bool softDelete = true, bool saveChanges = false);

        /// <summary>
        /// Remove a range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="softDelete"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(IEnumerable<TEntity> entities, bool softDelete = true, bool saveChanges = false);

        /// <summary>
        /// Begin new transaction with specified isolation level
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        Task BeginTransactionAsync(IsolationLevel isolationLevel);

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
