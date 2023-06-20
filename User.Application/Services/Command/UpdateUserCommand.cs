using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using User.Domain.ValueObjects;

namespace User.Application.Services.Command
{
    public class UpdateUserCommand: IRequest
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
    }
}
