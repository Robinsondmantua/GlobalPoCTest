using Application.Common.Interfaces;
using Infraestructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class NotificationService : IEventNotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContext _context;
        private readonly IMediator _mediator;

        public NotificationService(IUnitOfWork unitOfWork, IContext context, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mediator = mediator;
        }

        public async Task Notify()
        {
            var events = _context.Inventories.SelectMany(x => x.DomainEvents.Where(x => x.IsPublished == false))
                .Union(_context.Items.SelectMany(x=>x.DomainEvents.Where(x => x.IsPublished == false))).ToList();

            foreach(var @event in events)
            {
                @event.IsPublished = true;
                await _mediator.Publish(@event);
            }
        }
    }
}
