using MassTransit;
using Microsoft.Extensions.Hosting;

namespace User.Application.Messaging
{
    public class UserPublisher : BackgroundService
    {
        private readonly IBus _bus;
        public UserPublisher(IBus bus)
        {
            _bus = bus;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

        }
    }
}
