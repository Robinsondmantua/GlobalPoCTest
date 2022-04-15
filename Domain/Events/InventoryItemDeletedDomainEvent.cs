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
    /// Event when removing an item form the inventory 
    /// </summary>
    public class InventoryItemDeletedDomainEvent : DomainEvent
    {
        public Item Item { get; }

        public InventoryItemDeletedDomainEvent(Item item)
        {
            Item = item;
        }
    }
}
