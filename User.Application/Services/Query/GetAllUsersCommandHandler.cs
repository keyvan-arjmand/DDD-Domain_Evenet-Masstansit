using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Application.Services.Command;
using User.Application.Services.Models;

namespace User.Application.Services.Query
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, List<UserDto>>
    {
        private readonly IRepository<Domain.Entities.User> _Service;
        private readonly IMapper _mapper;

        public GetAllUsersCommandHandler(IRepository<Domain.Entities.User> service, IMapper mapper)
        {
            _mapper = mapper;
            _Service = service;
        }
        public async Task<List<UserDto>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            var result = await _Service.GetAllAsync();
            return await Task.FromResult(_mapper.Map<List<Domain.Entities.User>, List<UserDto>>(result.ToList()));

        }
    }
}
