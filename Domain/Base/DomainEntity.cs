using System;

namespace Domain.Base
{
    public abstract class DomainEntity<TId> : DomainEntity where TId : struct
    {
        public TId Id { get; set; }
    }

    public abstract class DomainEntity
    {
        public DateTime CreatedDateUtc { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDateUtc { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
