using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;
using User.Domain.ValueObjects;

namespace User.Application.Services.Command
{
    public class CreateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public string Details { get; set; }
    }
}
