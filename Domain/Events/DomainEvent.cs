using Domain.Base;
using System;

namespace Domain.Events
{
    public abstract class DomainEvent<TEntity> where TEntity : DomainEntity
    {
        public DomainEvent(TEntity entity)
        {
            EventName = GetType().Name;
            EventBody = entity;
            CreatedDateUtc = DateTime.UtcNow;
        }

        public string EventName { get; }

        public string EntityName => typeof(TEntity).FullName;

        public TEntity EventBody { get; }

        public DateTime CreatedDateUtc { get; }
    }
}
