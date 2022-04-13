using Domain.Aggregate;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class Context : IContext
    {
        public List<Item> Items { get; set; }
        public List<Inventory>? Inventories { get; set; }
    }

    public interface IContext
    {
        List<Item> Items { get; set; }
        List<Inventory> Inventories { get; set; } 
    }
}
