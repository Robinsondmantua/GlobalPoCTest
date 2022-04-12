using Application.Features.Item.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Commands.Request
{
    public class DeleteItemCommandRequest : IRequest<ItemDto>
    {
        public string Id { get; set; }

        public DeleteItemCommandRequest(string id)
        {
            Id = id;
        }

    }
}
