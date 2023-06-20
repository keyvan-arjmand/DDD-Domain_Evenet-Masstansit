using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using User.Application.Contracts;
using User.Domain.ValueObjects;

namespace User.Application.Services.Command
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IRepository<Domain.Entities.User> _Service;

        public UpdateUserCommandHandler(IRepository<Domain.Entities.User> service)
        {
            _Service = service;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            await _Service.UpdateOne(new Domain.Entities.User
            {
                Id = new ObjectId(request.Id),
                LastName = request.LastName,
                Name = request.Name,
                PassWord = request.PassWord,
                PhoneNumber = new PhoneNumber(request.PhoneNumber),
                UserName = request.UserName,
            });
            await Task.CompletedTask;
        }

    }
}
