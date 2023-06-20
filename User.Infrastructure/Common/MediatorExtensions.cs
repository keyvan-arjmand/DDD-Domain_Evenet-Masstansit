using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;
namespace MediatR;

public static class MediatorExtensions
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, AggregateRoot aggregateRoot)
    {
        var domainEvents = aggregateRoot.DomainEvents;

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent).ConfigureAwait(false);

        aggregateRoot.ClearDomainEvents();

    }
}