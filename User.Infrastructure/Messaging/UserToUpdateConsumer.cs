﻿using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Domain.Event;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Messaging
{
    public class UserToUpdateConsumer : IConsumer<UserUpdatedDomainEvent>
    {
        private readonly IRepository<Domain.Entities.User> _Service;
        public UserToUpdateConsumer(IRepository<Domain.Entities.User> service)
        {
            _Service = service;
        }


        public async Task Consume(ConsumeContext<UserUpdatedDomainEvent> context)
        {
            var user = await _Service.GetByIdAsync(context.Message.Id);
            user.Details = context.Message.Details;
            user.LastName = context.Message.LastName;
            user.Name = context.Message.Name;
            user.PassWord = context.Message.PassWord;
            user.PhoneNumber = context.Message.PhoneNumber;
            user.UserName = context.Message.UserName;
            user.Id = context.Message.Id;
            await _Service.UpdateAsync(x => x.Id == user.Id, user, new Expression<Func<Domain.Entities.User, object>>[] { }, null);
        }
    }
}
