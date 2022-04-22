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
    /// This class receives the request for inserting an item
    /// </summary>
    public class NewItemCommandRequest : IRequest<ItemDto>
    {
        public NewItemDto RequestParams { get; set; }

        public NewItemCommandRequest(NewItemDto requestParams)
        {
            RequestParams = requestParams;
        }
    }
}
