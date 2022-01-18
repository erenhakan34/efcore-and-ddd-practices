using Domain.Events;
using System;
using System.Collections.Generic;

namespace Domain.Base
{
    public abstract class DomainEntity<TId> : DomainEntity where TId : struct
    {
        public TId Id { get; set; }

        public List<object> Events = new List<object>();

        public void AddEvent(object domainEvent)
        {
            Events.Add(domainEvent);
        }

        public override bool Equals(object value)
        {
            if ((value is DomainEntity<TId> entity))
            {
                return entity.Id.ToString() == Id.ToString();
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public abstract class DomainEntity
    {
        public DateTime CreatedDateUtc { get; private set; }

        public string CreatedBy { get; private set; }

        public DateTime? UpdatedDateUtc { get; private set; }

        public string UpdatedBy { get; private set; }

        public bool IsDeleted { get; private set; }

        public void SetUpdatedAudit(string updatedBy = null)
        {
            UpdatedDateUtc = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }

        public void SetCreatedAudit(string createdBy = null)
        {
            CreatedDateUtc = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void SetDeleted()
        {
            IsDeleted = true;
        }
    }
}
