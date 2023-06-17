using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Application.Services.Models;

namespace User.Application.Services.Query
{
    public class GetByIdUserCommandHandler : IRequestHandler<GetByIdUserCommand, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.User> _Service;

        public GetByIdUserCommandHandler(IRepository<Domain.Entities.User> service, IMapper mapper)
        {
            _Service = service;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetByIdUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _Service.GetByIdAsync(request.Id);
            return await Task.FromResult(
                _mapper.Map<Domain.Entities.User, UserDto>(result));
        }
    }
}
