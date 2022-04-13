using Application.Common.Dtos;
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
    public class DeleteInventoryCommandRequest: IRequest<Unit>
    {
        public IdentityDto RequestParams { get; set; }
        public DeleteInventoryCommandRequest(IdentityDto requestParams)
        {
            RequestParams = requestParams;
        }

    }
}
