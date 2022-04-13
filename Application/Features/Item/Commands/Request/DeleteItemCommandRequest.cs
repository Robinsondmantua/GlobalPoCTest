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
        public string Id { get; set; }

        public DeleteItemCommandRequest(string id)
        {
            Id = id;
        }

    }
}
