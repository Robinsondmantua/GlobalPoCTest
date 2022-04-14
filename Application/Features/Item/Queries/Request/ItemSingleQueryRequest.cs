using Application.Features.Item.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Queries.Request
{
    /// <summary>
    /// This class receives the request for getting a single item
    /// </summary>
    public class ItemSingleQueryRequest: IRequest<ItemDto>
    {
        public Guid Id { get; set; }
        public ItemSingleQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
