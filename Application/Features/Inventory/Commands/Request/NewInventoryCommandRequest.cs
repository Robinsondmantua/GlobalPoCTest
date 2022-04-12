﻿using Application.Features.Inventory.Dtos;
using Application.Features.Item.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Commands.Request
{
    /// <summary>
    /// This class receives the request for inserting an inventory
    /// </summary>
    public class NewTodoItemCommand : IRequest<InventoryDto>
    {
        public string Name { get; set; }
        public IEnumerable<ItemDto>? Items { get; set;}

        public NewTodoItemCommand(string name)
        {
            Name = name;
        }
    }
}
