using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using User.Domain.Event;

namespace User.Application.EventHandlers;

public class UserDeletedDomainEventHandler : INotificationHandler<UserDeletedDomainEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<UserDeletedDomainEventHandler> _logger;

    public UserDeletedDomainEventHandler(IPublishEndpoint publishEndpoint, ILogger<UserDeletedDomainEventHandler> logger)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task Handle(UserDeletedDomainEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await _publishEndpoint.Publish<UserDeletedDomainEvent>(new UserDeletedDomainEvent
            {
                Id = notification.Id,
            }, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
    }
}