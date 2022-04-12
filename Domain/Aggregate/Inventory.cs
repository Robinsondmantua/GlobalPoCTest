using Domain.Common.Events;
using Domain.Entities;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregate
{
    /// <summary>
    /// Inventory's Aggregate 
    /// </summary>
    public class Inventory: EntityBase, IDomainEvent
    {
        
        public string Name { get; private set; }
        public string Description { get; private set; }

        private readonly List<Item>? _items;
        public IReadOnlyCollection<Item>? Items => _items;

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public void AddItem()
        {

        }

        public void RemoveItem()
        {

        }

        public void CheckItemsExpired()
        {

        }
    }
}
