using Application.Features.Item.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Commands.Request
{
    public class PatchItemCommandRequest: IRequest<ItemDto>
    {
        public ItemDto RequestParams { get; set; }

        public PatchItemCommandRequest(ItemDto requestParams)
        {
            RequestParams = requestParams;
        }
    }
}
