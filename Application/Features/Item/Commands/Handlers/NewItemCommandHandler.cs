using Application.Common.Interfaces;
using Application.Features.Item.Commands.Request;
using Application.Features.Item.Dtos;
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
    /// Command class to process a request for inserting an item
    /// </summary>
    public class NewItemCommandHandler : IRequestHandler<NewItemCommandRequest, ItemDto>
    {
        private readonly ICommandRepository<Domain.Entities.Item> _itemCommandRepository;
        private readonly IMapper _mapper;

        public NewItemCommandHandler(ICommandRepository<Domain.Entities.Item> itemCommandRepository, IMapper mapper)
        {
            _itemCommandRepository = itemCommandRepository;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(NewItemCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = Domain.Entities.Item.Create(request.RequestParams.Name, request.RequestParams.Type.Value, request.RequestParams.ExpirationDate);
            var result = await Task.Run(() => { return _itemCommandRepository.AddAsync(entity); });
            return _mapper.Map<ItemDto>(result);
        }
    }
}
