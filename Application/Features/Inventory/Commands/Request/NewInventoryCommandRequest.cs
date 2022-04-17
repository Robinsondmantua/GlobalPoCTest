using Application.Features.Inventory.Dtos;
using Application.Features.Item.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Commands.Request
{
    /// <summary>
    /// This class receives the request for inserting an inventory
    /// </summary>
    public class NewInventoryCommandRequest : IRequest<InventoryDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Guid>? Items { get; set;}

        public NewInventoryCommandRequest(string name)
        {
            Name = name;
        }
    }
}
