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
    public class UserDeletedDomainEventHandler : INotificationHandler<UserDeletedDomainEvent>
    {
        private readonly IRepository<Domain.Entities.User> _Service;
        public UserDeletedDomainEventHandler(IRepository<Domain.Entities.User> service)
        {
            _Service = service;
        }
        public async Task Handle(UserDeletedDomainEvent notification, CancellationToken cancellationToken)
        {
            var user = await _Service.GetByIdAsync(notification.Id);
            await _Service.DeleteAsync(user);
            await _Service.SaveChangesAsync(cancellationToken);
        }
    }
}
