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
    public class UserToUpdateConsumer : IConsumer<UserToUpdate>
    {
        private readonly DB _db;

        public UserToUpdateConsumer(DB db)
        {
            _db = db;
        }

        public Task Consume(ConsumeContext<UserToUpdate> context)
        {
            var user = context.Message.User;
            UserUpdatedDomainEvent userEvent = new UserUpdatedDomainEvent(user);
            user.RaiseDomainEvent(userEvent);
            return Task.CompletedTask;
        }
    }
}
