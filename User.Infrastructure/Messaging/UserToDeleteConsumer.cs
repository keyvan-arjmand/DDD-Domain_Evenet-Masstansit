﻿using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Domain.Event;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Messaging
{
    public class UserToDeleteConsumer : IConsumer<UserDeletedDomainEvent>
    {
        private readonly IRepository<Domain.Entities.User> _Service;
        public UserToDeleteConsumer(IRepository<Domain.Entities.User> service)
        {
            _Service = service;
        }

        public async Task Consume(ConsumeContext<UserDeletedDomainEvent> context)
        {
            var user = await _Service.GetByIdAsync(context.Message.Id);
            await _Service.DeleteAsync(x => x.Id == context.Message.Id, user);
        }
    }
}
