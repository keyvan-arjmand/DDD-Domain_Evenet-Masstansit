using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Domain.Event;

namespace User.Application.Services.Command
{
    public class UserUpdatedDomainEventHandler : INotificationHandler<UserUpdatedDomainEvent>
    {
        private readonly IRepository<Domain.Entities.User> _Service;
        public UserUpdatedDomainEventHandler(IRepository<Domain.Entities.User> service)
        {
            _Service = service;
        }
        public async Task Handle(UserUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _Service.UpdateAsync(notification.User);
            await _Service.SaveChangesAsync(cancellationToken);
        }
    }
}
