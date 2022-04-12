using Application.Features.Inventory.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Commands.Request
{
    public class PatchInventoryCommandRequest : IRequest<InventoryDto>
    {

    }
}
