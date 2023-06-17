﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Application.Services.Models;
using User.Application.Services.Query;
using User.Domain.Event;

namespace User.Application.Services.Command
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IRepository<Domain.Entities.User> _Service;

        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IRepository<Domain.Entities.User> service, IMapper mapper)
        {
            _Service = service;
            _mapper = mapper;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _Service.GetByIdAsync(request.Id);
            //user.AddDomainEvent(new UserCreatedDomainEvent(user));
            await _Service.DeleteAsync(user);
            await _Service.SaveChangesAsync();
        }
    }
}
