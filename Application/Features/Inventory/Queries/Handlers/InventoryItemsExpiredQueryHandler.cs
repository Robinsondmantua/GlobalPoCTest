using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Inventory.Dtos;
using Application.Features.Inventory.Queries.Request;
using AutoMapper;
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
    /// Query class to process a request for getting expired items from an inventory 
    /// </summary>
   
    public class InventoryItemsExpiredQueryHandler : IRequestHandler<InventoryItemExpiredQueryRequest, InventoryDto>
    {
        private readonly IQueryRepository<Domain.Aggregate.Inventory> _inventoryQueryRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public InventoryItemsExpiredQueryHandler(IQueryRepository<Domain.Aggregate.Inventory> inventoryQueryRepository, IMapper mapper, IMediator mediator)
        {
            _inventoryQueryRepository = inventoryQueryRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<InventoryDto> Handle(InventoryItemExpiredQueryRequest request, CancellationToken cancellationToken)
        {
            var inventory = _inventoryQueryRepository.GetByIdAsync(request.Id).Result;

            if (inventory is null)
            {
                throw new NotFoundException("Inventory not found");
            }

            inventory.CheckItemsExpired();

            foreach (var @event in inventory.DomainEvents)
            {
                if (@event is InventoryItemExpiredDomainEvent)
                {
                    await _mediator.Publish(@event, cancellationToken);
                }
            }

            return _mapper.Map<InventoryDto>(inventory);
        }
    }
}
