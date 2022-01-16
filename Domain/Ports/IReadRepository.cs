using Domain.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IReadRepository<TId> where TId : struct
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : DomainEntity<TId>;

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get<TEntity>(TId id) where TEntity : DomainEntity<TId>;

        /// <summary>
        /// Get entity by custom expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : DomainEntity<TId>;


        /// <summary>
        /// Check entity if exists
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : DomainEntity<TId>;

        /// <summary>
        /// Get counts of entity by giving criteria
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : DomainEntity<TId>;
    }
}
