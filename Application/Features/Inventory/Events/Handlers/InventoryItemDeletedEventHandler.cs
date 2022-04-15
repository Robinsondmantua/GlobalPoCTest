using Application.Features.Inventory.Events.Notification;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Events
{
    public class InventoryItemDeletedEventHandler : INotificationHandler<InventoryItemDeletedEventNotificacion>
    {
        private readonly ILogger<InventoryItemDeletedEventHandler> _logger;

        public InventoryItemDeletedEventHandler(ILogger<InventoryItemDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(InventoryItemDeletedEventNotificacion notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
