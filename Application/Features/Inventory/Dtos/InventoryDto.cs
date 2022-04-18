using Application.Features.Item.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Dtos
{
    /// <summary>
    /// Dto to transfer information between layers
    /// </summary>
    public class InventoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ItemDto> Items { get; set; }

    }
}
