using System;

namespace Domain.Base
{
    public abstract class Entity<TId> : Entity where TId : struct
    {
        public TId Id { get; set; }
    }

    public abstract class Entity 
    {
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
