using Application.Features.Inventory.Commands.Request;
using Application.Features.Inventory.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Queries.Handlers
{
    public class NewInventoryCommandHandler : IRequestHandler<NewInventoryCommandRequest, InventoryDto>
    {
        public Task<InventoryDto> Handle(NewInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
