using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Inventory.Commands.Request;
using Application.Features.Inventory.Events.Notification;
using Application.Features.Item.Commands.Request;
using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Queries.Handlers
{
    public class DeleteItemInventoryCommandHandler : IRequestHandler<DeleteItemInventoryCommandRequest, Unit>
    {
        private readonly ICommandRepository<Domain.Aggregate.Inventory> _inventoryCommandRepository;
        private readonly IQueryRepository<Domain.Aggregate.Inventory> _inventoryQueryRepository;
        private readonly IMediator _mediator;

        public DeleteItemInventoryCommandHandler(ICommandRepository<Domain.Aggregate.Inventory> inventoryCommandRepository, IQueryRepository<Domain.Aggregate.Inventory> inventoryQueryRepository, IMediator mediator)
        {
            _inventoryCommandRepository = inventoryCommandRepository;
            _inventoryQueryRepository = inventoryQueryRepository;
            _mediator = mediator;
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
                }
                
                await _inventoryCommandRepository.UpdateAsync(inventory);
            }
            else
            {
                throw new NotFoundException("Inventory not found");
            }

            return default;
        }
    }
}
