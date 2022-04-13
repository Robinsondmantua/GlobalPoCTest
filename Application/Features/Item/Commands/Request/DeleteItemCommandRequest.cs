using Application.Features.Item.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Commands.Request
{
    /// <summary>
    /// This class receives the request for removing an item
    /// </summary>
    public class DeleteItemCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteItemCommandRequest(Guid id)
        {
            Id = id;
        }

    }
}
