using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Services.Models;

namespace User.Application.Services.Query
{
    public class GetByIdUserCommand:IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
