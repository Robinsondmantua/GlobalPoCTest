using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Events;
using MediatR;

namespace Application.Common.Interfaces;
public class DomainEventWrapper<T> : INotification where T : DomainEvent
{
    public T DomainEvent { get; }

    public DomainEventWrapper(T domainEvent)
    {
        DomainEvent = domainEvent;
    }
}
