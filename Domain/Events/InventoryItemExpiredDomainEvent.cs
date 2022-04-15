using Domain.Common.Events;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    /// <summary>
    /// Event when an item form the inventory is expired
    /// </summary>
    public class InventoryItemExpiredDomainEvent : DomainEvent
    {
        public Item Item { get; }

        public InventoryItemExpiredDomainEvent(Item item)
        {
            Item = item;
        }
    }

}
