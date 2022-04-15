using Application.Features.Inventory.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Queries.Request
{
    /// <summary>
    /// This class receives the request for getting one inventory
    /// </summary>

    public class InventoryItemExpiredQueryRequest : IRequest<InventoryDto>
    {
        public Guid Id { get; set; }
        public InventoryItemExpiredQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
