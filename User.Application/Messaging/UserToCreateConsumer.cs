using MassTransit;
using User.Application.Contracts;
using User.Domain.Entities;
using User.Domain.Event;

namespace User.Application.Messaging
{

    public class UserToCreateConsumer : IConsumer<UserCreatedDomainEvent>
    {
        private readonly IRepository<Domain.Entities.User> _Service;
        public UserToCreateConsumer(IRepository<Domain.Entities.User> service)
        {
            _Service = service;
        }
        public async Task Consume(ConsumeContext<UserCreatedDomainEvent> context)
        {
            await _Service.AddAsync(new Domain.Entities.User
            {
                Details = context.Message.Details,
                LastName = context.Message.LastName,
                PassWord = context.Message.PassWord,
                PhoneNumber = context.Message.PhoneNumber,
                UserName = context.Message.UserName,
                Name = context.Message.Name,
            });
        }
    }
}
