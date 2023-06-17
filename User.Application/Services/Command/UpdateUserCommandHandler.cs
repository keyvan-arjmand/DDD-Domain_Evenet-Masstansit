using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;

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
            await _Service.UpdateAsync(new Domain.Entities.User
            {
                Id = request.Id,
                LastName = request.LastName,
                Name = request.Name,
                PassWord = request.PassWord,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
            });
            await Task.CompletedTask;
        }

    }
}
