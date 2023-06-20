using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using User.Domain.Event;

namespace User.Application.EventHandlers
{

    public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<UserCreatedDomainEventHandler> _logger;

        public UserCreatedDomainEventHandler(IPublishEndpoint publishEndpoint, ILogger<UserCreatedDomainEventHandler> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                await _publishEndpoint.Publish<UserCreatedDomainEvent>(new UserCreatedDomainEvent
                {
                    Details = notification.Details,
                    LastName = notification.LastName,
                    Name = notification.Name,
                    PassWord = notification.PassWord,
                    PhoneNumber = notification.PhoneNumber,
                    UserName = notification.UserName,
                }, cancellationToken).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
