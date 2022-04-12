﻿using Application.Features.Item.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Queries.Request
{
    public class ItemSingleQueryRequest: IRequest<ItemDto>
    {
        public int Id { get; set; }
        public ItemSingleQueryRequest(int id)
        {
            Id = id;
        }
    }
}
