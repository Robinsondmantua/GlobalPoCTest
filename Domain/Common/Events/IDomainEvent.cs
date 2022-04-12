using Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Events
{
    public interface IDomainEvent
    {
        public List<DomainEvent> DomainEvents { get;  set; }
    }
}
