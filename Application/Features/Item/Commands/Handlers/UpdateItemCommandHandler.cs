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
    /// Command class to process a request for update an item
    /// </summary>
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommandRequest, ItemDto>
    {
        private readonly ICommandRepository<Domain.Entities.Item> _itemCommandRepository;
        private readonly IQueryRepository<Domain.Entities.Item> _itemQueryRepository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(ICommandRepository<Domain.Entities.Item> itemCommandRepository, IQueryRepository<Domain.Entities.Item> itemQueryRepository, IMapper mapper)
        {
            _itemCommandRepository = itemCommandRepository;
            _itemQueryRepository = itemQueryRepository;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(UpdateItemCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Item>(request.RequestParams);
            await Task.Run(() => { return _itemCommandRepository.UpdateAsync(entity); });

            var updatedItem = await _itemQueryRepository.GetByIdAsync(request.RequestParams.Id);

            return _mapper.Map<ItemDto>(updatedItem);
        }
    }
}
