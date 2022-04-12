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
        private readonly List<Item>? _items;

        public string? Name { get; private set; }

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
