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
    /// Query class to process a request for getting all inventories
    /// </summary>
    
    public class InventoryAllQueryHandler : IRequestHandler<InventoryAllQueryRequest, IEnumerable<InventoryDto>>
    {
        private readonly IQueryRepository<Domain.Aggregate.Inventory> _inventoryQueryRepository;
        private readonly IMapper _mapper;

        public InventoryAllQueryHandler(IQueryRepository<Domain.Aggregate.Inventory> inventoryQueryRepository, IMapper mapper)
        {
            _inventoryQueryRepository = inventoryQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryDto>> Handle(InventoryAllQueryRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<InventoryDto>>(_inventoryQueryRepository.GetAllAsync().Result);
        }
    }
}
