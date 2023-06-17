using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;

namespace User.Domain.Event
{
    public class UserUpdatedDomainEvent : BaseEvent
    {
        public UserUpdatedDomainEvent(Domain.Entities.User user)
        {
            User = user;
        }

        public Domain.Entities.User User { get; }
    }
}
