using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Contracs;
using User.Domain.Event;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Messaging
{
    public class UserToDeleteConsumer : IConsumer<UserToDelete>
    {
        private readonly DB _db;

        public UserToDeleteConsumer(DB db)
        {
            _db = db;
        }

        public Task Consume(ConsumeContext<UserToDelete> context)
        {
            var user = context.Message.User;
            user.RaiseDomainEvent(new UserDeletedDomainEvent(user.Id));
            return Task.CompletedTask;
        }
    }
}
