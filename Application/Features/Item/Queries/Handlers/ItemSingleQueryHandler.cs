using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Item.Dtos;
using Application.Features.Item.Queries.Request;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Queries.Handlers
{
    /// <summary>
    /// Query class to process a request for getting one item by a filter
    /// </summary>

    public class ItemSingleQueryHandler : IRequestHandler<ItemSingleQueryRequest, ItemDto>
    {
        private readonly IQueryRepository<Domain.Entities.Item> _itemQueryRepository;
        private readonly IMapper _mapper;

        public ItemSingleQueryHandler(IQueryRepository<Domain.Entities.Item> itemQueryRepository, IMapper mapper)
        {
            _itemQueryRepository = itemQueryRepository;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(ItemSingleQueryRequest request, CancellationToken cancellationToken)
        {
            var item = _itemQueryRepository.GetByIdAsync(request.Id).Result;

            if (item is null)
            {
                throw new NotFoundException("Item not found");
            }

            return _mapper.Map<ItemDto>(item); 
        }
    }
}
