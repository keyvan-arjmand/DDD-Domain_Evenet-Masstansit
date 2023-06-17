using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Domain;
using User.Domain.Event;

namespace User.Application.Services.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IRepository<Domain.Entities.User> _Service;

        public CreateUserCommandHandler(IRepository<Domain.Entities.User> service)
        {
            _Service = service;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = new Domain.Entities.User
            {
                LastName = request.LastName,
                Name = request.Name,
                PassWord = request.PassWord,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
            };

            //user.AddDomainEvent(new UserCreatedDomainEvent(user));
            await _Service.AddAsync(user);
            await _Service.SaveChangesAsync();
        }
    }
}
