using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Inventory.Commands.Request;
using Application.Features.Inventory.Dtos;
using Application.Features.Inventory.Queries.Request;
using Application.Features.Item.Commands.Request;
using Application.Features.Item.Dtos;
using Application.Features.Item.Queries.Handlers;
using Application.Features.Item.Queries.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers
{
    public class InventoryController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [SwaggerOperation("Create an inventory.")]
        public async Task<ActionResult<InventoryDto>> CreateInventory([FromBody] NewInventoryCommandRequest command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction(nameof(CreateInventory), result);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delete an existing item in the inventory.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteInventoryItem([FromBody] DeleteItemInventoryCommandRequest command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerOperation("Get all inventories.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<InventoryDto>> GetAll()
        {
            var result = await Mediator.Send(new InventoryAllQueryRequest());
            return result.ToList();
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Get an inventory by its identifier.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<InventoryDto> Get(Guid id)
        {
            return await Mediator.Send(new InventorySingleQueryRequest(id));
        }

        [HttpGet("GetInventoryItemsExpired/{id}")]
        [SwaggerOperation("Get all expired items of an inventory.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<InventoryDto> GetInventoryItemsExpired(Guid id)
        {
            var result = await Mediator.Send(new InventoryItemExpiredQueryRequest(id));
            return result;
        }
    }
}
