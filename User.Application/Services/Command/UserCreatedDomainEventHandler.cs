using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Domain.Entities;
using User.Domain.Event;

namespace User.Application.Services.Command
{

    public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
    {
        private readonly IRepository<Domain.Entities.User> _Service;
        private readonly IPublishEndpoint _bus;

        public UserCreatedDomainEventHandler(IPublishEndpoint bus, IRepository<Domain.Entities.User> service)
        {
            _Service = service;
            _bus = bus;
        }

        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _bus.Publish(notification.User);
            await _Service.AddAsync(notification.User);
            await _Service.SaveChangesAsync(cancellationToken);
        }
    }
}
