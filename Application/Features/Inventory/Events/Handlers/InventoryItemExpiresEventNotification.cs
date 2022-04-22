using Application.Common.Interfaces;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Events.Handlers
{
    /// <summary>
    /// Event handler for tracing an event's information.
    /// </summary>

    public class InventoryItemExpiresEventNotification : INotificationHandler<DomainEventWrapper<InventoryItemExpiredDomainEvent>>
    {
        private readonly ILogger<InventoryItemExpiresEventNotification> _logger;

        public InventoryItemExpiresEventNotification(ILogger<InventoryItemExpiresEventNotification> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventWrapper<InventoryItemExpiredDomainEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
