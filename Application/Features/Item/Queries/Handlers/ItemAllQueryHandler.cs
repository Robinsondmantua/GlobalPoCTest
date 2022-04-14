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
    /// Query class to process a request for getting all items
    /// </summary>
    public class ItemAllQueryHandler : IRequestHandler<ItemAllQueryRequest, IEnumerable<ItemDto>>
    {
        private readonly IQueryRepository<Domain.Entities.Item> _itemQueryRepository;
        private readonly IMapper _mapper;

        public ItemAllQueryHandler(IQueryRepository<Domain.Entities.Item> itemQueryRepository, IMapper mapper)
        {
            _itemQueryRepository = itemQueryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDto>> Handle(ItemAllQueryRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ItemDto>>(_itemQueryRepository.GetAllAsync());  
        }
    }
}
