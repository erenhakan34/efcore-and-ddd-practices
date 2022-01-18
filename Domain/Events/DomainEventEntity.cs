using System;

namespace Domain.Events
{
    public class DomainEventEntity 
    {
        public int CustomerId { get; set; }

        public string EventName { get; set; }

        public string EntityName { get; set; }

        public string EventBody { get; set; }

        public DateTime CreatedDateUtc { get; }
    }
}
