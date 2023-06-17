using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;
using User.Domain.Entities;

namespace User.Domain.Event
{
    public class UserCreatedDomainEvent : BaseEvent
    {
        public UserCreatedDomainEvent(Domain.Entities.User user)
        {
            User = user;
        }

        public Domain.Entities.User User { get; }
    }
}
