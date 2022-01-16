using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IReadRepository<TEntity> where TEntity : DomainEntity<int>
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Get entity by custom expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    }
}
