using System;

namespace Domain.Base
{
    public abstract class DomainEntity<TId> : DomainEntity where TId : struct
    {
        public TId Id { get; set; }


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

    public abstract class DomainEntity
    {
        public DateTime CreatedDateUtc { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDateUtc { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
