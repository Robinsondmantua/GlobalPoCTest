using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Item.Commands.Request;
using Application.Features.Item.Dtos;
using Application.Features.Item.Queries.Handlers;
using Application.Features.Item.Queries.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers
{
    public class ItemController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemCommandRequest command)
        {
            if (!id.Equals(command.RequestParams.Id))
            {
                return BadRequest();
            }

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerOperation("Get all items.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<List<ItemDto>> GetAll()
        {
            var result = await Mediator.Send(new ItemAllQueryRequest());
            return result.ToList();
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Get an item by its identifier.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ItemDto> Get(Guid id)
        {
            return await Mediator.Send(new ItemSingleQueryRequest(id));
        }
    }
}
