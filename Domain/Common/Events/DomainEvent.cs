using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Events
{
    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            DateRaised = DateTime.UtcNow;
        }
        public DateTimeOffset DateRaised {get; protected set; } = DateTime.UtcNow; 
    }
}
