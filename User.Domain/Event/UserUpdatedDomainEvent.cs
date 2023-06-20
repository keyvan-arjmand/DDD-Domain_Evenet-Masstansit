using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using User.Domain.Common;
using User.Domain.Entities;
using User.Domain.ValueObjects;

namespace User.Domain.Event
{
    public class UserUpdatedDomainEvent : BaseEvent
    {
        public ObjectId Id { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public UserDetails Details { get; set; }
    }
}
