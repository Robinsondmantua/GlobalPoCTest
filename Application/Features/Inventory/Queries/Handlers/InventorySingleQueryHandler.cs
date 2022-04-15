using Application.Common.Interfaces;
using Application.Features.Inventory.Dtos;
using Application.Features.Inventory.Queries.Request;
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
    /// Query class to process a request for getting one inventory by a filter
    /// </summary>
   
    public class InventorySingleQueryHandler : IRequestHandler<InventorySingleQueryRequest, InventoryDto>
    {
        private readonly IQueryRepository<Domain.Aggregate.Inventory> _inventoryQueryRepository;
        private readonly IMapper _mapper;

        public InventorySingleQueryHandler(IQueryRepository<Domain.Aggregate.Inventory> inventoryQueryRepository, IMapper mapper)
        {
            _inventoryQueryRepository = inventoryQueryRepository;
            _mapper = mapper;
        }

        public async Task<InventoryDto> Handle(InventorySingleQueryRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<InventoryDto>(_inventoryQueryRepository.GetByIdAsync(request.Id).Result);
        }
    }
}
