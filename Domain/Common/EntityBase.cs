using Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common 
{
    public class EntityBase
    {
        public Guid Id {get; protected set;}
        public ICollection<IDomainEvent>? Events { get; }
    }
}
