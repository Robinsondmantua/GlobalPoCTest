using Domain.Common.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Events.Notification
{
    /// <summary>
    /// Request for receiving an event.
    /// </summary>

    public class InventoryItemExpiresEventNotificacion : INotification
    {
        public DomainEvent DomainEvent { get; set; }

        public InventoryItemExpiresEventNotificacion(DomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
