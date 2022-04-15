using Domain.Common.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Events.Notification
{
    public class InventoryItemDeletedEventNotificacion : INotification
    {
        public DomainEvent DomainEvent { get; set; }

        public InventoryItemDeletedEventNotificacion(DomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
