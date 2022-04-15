using Domain.Common.Events;
using Domain.Entities;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Events;

namespace Domain.Aggregate
{
    /// <summary>
    /// Inventory's Aggregate 
    /// </summary>
    public class Inventory: EntityBase, IHasDomainEvent 
    {
        
        public string Name { get; private set; }
        public string Description { get; private set; }

        private readonly List<Item> _items = new List<Item>();
        public IReadOnlyCollection<Item> Items => _items;

        public List<DomainEvent> DomainEvents { get; set;}

        public void Create(string _name, string _description)
        {
            Id = new Guid();
            Name = _name;
            Description = _description;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public InventoryItemDeletedDomainEvent RemoveItem(Item item)
        {
            _items.Remove(item);
            return new InventoryItemDeletedDomainEvent(item);
        }

        public void CheckItemsExpired()
        {
            foreach (var _item in _items)
            {
                if(_item.ExpirationDate < DateTime.UtcNow)
                {
                    DomainEvents.Add(new InventoryItemExpiredDomainEvent(_item));
                }
            }
        }
    }
}
