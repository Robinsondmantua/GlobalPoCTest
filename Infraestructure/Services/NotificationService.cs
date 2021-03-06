using Application.Common.Interfaces;
using Domain.Common.Events;
using Infraestructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    /// <summary>
    /// Service for traking events (Simulates a traking in a ORM)
    /// </summary>
    public class NotificationService : IEventNotificationService
    {
        private readonly IContext _context;
        private readonly IMediator _mediator;

        public NotificationService(IContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task Notify()
        {
            var events = _context.Inventories.SelectMany(x => x.DomainEvents.Where(x => !x.IsPublished))
                .Union(_context.Items.SelectMany(x=>x.DomainEvents.Where(x => !x.IsPublished))).ToList();

            foreach(var @event in events)
            {
                @event.IsPublished = true;
                var eventToPublish = GetEventToPublish(@event);
                await _mediator.Publish(eventToPublish);
            }
        }

        private INotification GetEventToPublish(DomainEvent @event)
        {
            return (INotification)Activator.CreateInstance(
                typeof(DomainEventWrapper<>).MakeGenericType(@event.GetType()), @event)!;
        }
    }
}
