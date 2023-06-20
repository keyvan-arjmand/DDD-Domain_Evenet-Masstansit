using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MongoDB.Bson;
using User.Application.Contracts;
using User.Domain;
using User.Domain.Entities;
using User.Domain.Event;
using User.Domain.ValueObjects;
using MassTransit.Mediator;
using User.Domain.Common;
using MediatR;
using IMediator = MediatR.IMediator;

namespace User.Application.Services.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IRepository<Domain.Entities.User> _Service;
        private readonly IMediator _mediator;
        public CreateUserCommandHandler(IRepository<Domain.Entities.User> service, IMediator mediator)
        {
            _Service = service;
            _mediator = mediator;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            Domain.Entities.User user = new Domain.Entities.User();
            
            user.AddDomainEvent(new UserCreatedDomainEvent
            {
                LastName = request.LastName,
                Name = request.Name,
                PassWord = request.PassWord,
                PhoneNumber = new PhoneNumber(request.PhoneNumber),
                UserName = request.UserName,
                Details = new UserDetails(request.Details),
            });
           await _Service.AddAsync(user);

        }
    }
}
