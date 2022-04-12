using Domain.Common.Events;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class ItemExpiredDomainEvent : DomainEvent
    {
        public Item Item { get; }

        public ItemExpiredDomainEvent(Item item)
        {
            Item = item;
        }
    }
}
