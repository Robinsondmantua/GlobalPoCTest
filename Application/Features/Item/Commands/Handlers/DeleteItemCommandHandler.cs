using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Item.Commands.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.Queries.Handlers
{
    /// <summary>
    /// Command class to process a request for deleting an item
    /// </summary>
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommandRequest, Unit> 
    {
        private readonly ICommandRepository<Domain.Entities.Item> _itemCommandRepository;
        private readonly IQueryRepository<Domain.Entities.Item> _itemQueryRepository;

        public DeleteItemCommandHandler(ICommandRepository<Domain.Entities.Item> itemCommandRepository, IQueryRepository<Domain.Entities.Item> itemQueryRepository)
        {
            _itemCommandRepository = itemCommandRepository;
            _itemQueryRepository = itemQueryRepository;
        }

        public async Task<Unit> Handle(DeleteItemCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _itemQueryRepository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException("Item not found");
            }
            await _itemCommandRepository.DeleteAsync(entity);

            return default;
        }
    }
}
