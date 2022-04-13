using Application.Features.Item.Dtos;
using Application.Features.Item.Queries.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Queries.Handlers
{
    /// <summary>
    /// Query class to process a request for getting all items
    /// </summary>
    public class ItemAllQueryHandler : IRequestHandler<ItemAllQueryRequest, IEnumerable<ItemDto>>
    {
        public Task<IEnumerable<ItemDto>> Handle(ItemAllQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
