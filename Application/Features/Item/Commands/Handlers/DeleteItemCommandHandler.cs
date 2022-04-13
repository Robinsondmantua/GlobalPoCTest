using Application.Features.Item.Commands.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Queries.Handlers
{
    /// <summary>
    /// Command class to process a request for deleting an item
    /// </summary>
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommandRequest, Unit> 
    {
        public Task<Unit> Handle(DeleteItemCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
