using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Infrastructure.Messaging
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
