using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Inventory.Commands.Request;
using Application.Features.Inventory.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Queries.Handlers
{
    /// <summary>
    /// Command to create an inventory
    /// </summary>
    public class NewInventoryCommandHandler : IRequestHandler<NewInventoryCommandRequest, InventoryDto>
    {
        private readonly ICommandRepository<Domain.Aggregate.Inventory> _inventoryCommandRepository;
        private readonly IQueryRepository<Domain.Aggregate.Inventory> _inventoryQueryRepository;
        private readonly IQueryRepository<Domain.Entities.Item> _itemsQueryRepository;
        private readonly IMapper _mapper;

        public NewInventoryCommandHandler(ICommandRepository<Domain.Aggregate.Inventory> inventoryCommandRepository, 
            IQueryRepository<Domain.Aggregate.Inventory> inventoryQueryRepository, 
            IQueryRepository<Domain.Entities.Item> itemsQueryRepository, IMapper mapper)
        {
            _inventoryCommandRepository = inventoryCommandRepository;
            _inventoryQueryRepository = inventoryQueryRepository;
            _itemsQueryRepository = itemsQueryRepository;
            _mapper = mapper;
        }

        public async Task<InventoryDto> Handle(NewInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            var existingItems = _itemsQueryRepository.GetAllAsync().Result.Select(x => x.Id);
            var itemsNotFounded = request.Items?.Except(existingItems).Any();

            if(itemsNotFounded ?? true)
            {
                throw new NotFoundException($"Item to add not found");
            }

            var newInventory = Domain.Aggregate.Inventory.Create(request.Name, request.Description);
            
            foreach(var item in request.Items)
            {
                var itemToAdd = await _itemsQueryRepository.GetByIdAsync(item);
                newInventory.AddItem(itemToAdd);
            }

            var result = await Task.Run(() => { return _inventoryCommandRepository.AddAsync(newInventory); });

            return _mapper.Map<InventoryDto>(result);
        }
    }
}
