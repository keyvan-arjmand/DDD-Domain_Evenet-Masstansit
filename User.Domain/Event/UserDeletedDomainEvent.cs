using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using User.Domain.Common;

namespace User.Domain.Event
{
    public class UserDeletedDomainEvent : BaseEvent
    {
        public ObjectId Id { get; set; }
    }
}
