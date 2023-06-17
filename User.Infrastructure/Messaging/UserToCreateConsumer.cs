using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Contracs;
using User.Domain.Entities;
using User.Domain.Event;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Messaging
{

    public class UserToCreateConsumer : IConsumer<UserToCreate>
    {
        private readonly DB _db;

        public UserToCreateConsumer(DB db)
        {
            _db = db;
        }


        public Task Consume(ConsumeContext<UserToCreate> context)
        {
            var user = context.Message.User;
            UserCreatedDomainEvent userEvent = new UserCreatedDomainEvent(user);
            user.RaiseDomainEvent(userEvent);
            return Task.CompletedTask;
        }
    }
}
