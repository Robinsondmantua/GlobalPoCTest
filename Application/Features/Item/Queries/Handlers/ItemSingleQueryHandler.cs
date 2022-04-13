﻿using Application.Features.Item.Dtos;
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
    /// Query class to process a request for getting one item by a filter
    /// </summary>

    public class ItemSingleQueryHandler : IRequestHandler<ItemSingleQueryRequest, ItemDto>
    {
        Task<ItemDto> IRequestHandler<ItemSingleQueryRequest, ItemDto>.Handle(ItemSingleQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
