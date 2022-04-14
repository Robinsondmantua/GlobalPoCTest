using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Item.Commands.Request;
using Application.Features.Item.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers
{
    public class ItemController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation("Create an item.")]
        public async Task<ActionResult<ItemDto>> CreateTodoItem([FromBody] NewItemCommandRequest command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction(nameof(CreateTodoItem), result);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delete an existing item.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var result = await Mediator.Send(new DeleteItemCommandRequest(id));
            return Ok(result);
        }

        [HttpPut("{id}")]
        [SwaggerOperation("Update an existing item.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemCommandRequest command)
        {
            if (command.RequestParams.Id == id)
            {
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
