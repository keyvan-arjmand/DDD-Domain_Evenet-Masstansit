using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;

namespace User.Domain.Event
{
    public class UserDeletedDomainEvent : BaseEvent
    {
        public UserDeletedDomainEvent(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
