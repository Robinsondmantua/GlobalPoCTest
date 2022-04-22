using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Inventory.Commands.Request;
using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Queries.Handlers
{
    /// <summary>
    /// Command to delete an inventory's item
    /// </summary>
    public class DeleteItemInventoryCommandHandler : IRequestHandler<DeleteItemInventoryCommandRequest, Unit>
    {
        private readonly ICommandRepository<Domain.Aggregate.Inventory> _inventoryCommandRepository;
        private readonly IQueryRepository<Domain.Aggregate.Inventory> _inventoryQueryRepository;

        public DeleteItemInventoryCommandHandler(ICommandRepository<Domain.Aggregate.Inventory> inventoryCommandRepository, IQueryRepository<Domain.Aggregate.Inventory> inventoryQueryRepository)
        {
            _inventoryCommandRepository = inventoryCommandRepository;
            _inventoryQueryRepository = inventoryQueryRepository;
        }

        public async Task<Unit> Handle(DeleteItemInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryQueryRepository.GetByIdAsync(request.InventoryId);

            if (inventory is null)
            {
                throw new NotFoundException("Inventory not found");
            }

            if (inventory.Items.Any(x => x.Name == request.ItemName))
            {
                var itemToRemove = inventory.Items.FirstOrDefault(x => x.Name == request.ItemName);
                
                if (itemToRemove is not null)
                {
                    inventory.DomainEvents.Add(new InventoryItemDeletedDomainEvent(itemToRemove));
                    inventory.RemoveItem(itemToRemove);
                }
                
                await _inventoryCommandRepository.UpdateAsync(inventory);
            }
            else
            {
                throw new NotFoundException("Item not found");
            }

            return default;
        }
    }
}
