using Application.Features.Item.Commands.Request;
using Application.Features.Item.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Queries.Handlers
{
    /// <summary>
    /// Command class to process a request for update an item
    /// </summary>
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommandRequest, ItemDto>
    {
        public Task<ItemDto> Handle(UpdateItemCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
