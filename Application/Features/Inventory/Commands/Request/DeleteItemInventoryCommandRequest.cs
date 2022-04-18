using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Commands.Request
{
    /// <summary>
    /// This class receives the request for removing an inventory
    /// </summary>
    public class DeleteItemInventoryCommandRequest: IRequest<Unit>
    {

        public Guid InventoryId { get; set; }
        public string ItemName { get; set; }

        public DeleteItemInventoryCommandRequest(Guid inventoryId, string itemName)
        {
            InventoryId = inventoryId;
            ItemName = itemName;
        }
    }
}
