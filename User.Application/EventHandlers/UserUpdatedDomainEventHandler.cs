using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using User.Domain.Event;

namespace User.Application.EventHandlers;

public class UserUpdatedDomainEventHandler : INotificationHandler<UserUpdatedDomainEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<UserUpdatedDomainEventHandler> _logger;

    public UserUpdatedDomainEventHandler(IPublishEndpoint publishEndpoint, ILogger<UserUpdatedDomainEventHandler> logger)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task Handle(UserUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await _publishEndpoint.Publish<UserUpdatedDomainEvent>(new UserUpdatedDomainEvent
            {
                Details = notification.Details,
                Id = notification.Id,
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