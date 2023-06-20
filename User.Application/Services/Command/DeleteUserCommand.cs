using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace User.Application.Services.Command
{
    public class DeleteUserCommand:IRequest
    {
        public ObjectId Id { get; set; }
    }
}
