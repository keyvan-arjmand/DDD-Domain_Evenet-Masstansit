using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Contracs;

namespace User.Domain.Common
{
    public abstract class EntityBase 
    {
        private List<BaseEvent> _domainEvents;
        public List<BaseEvent> DomainEvents => _domainEvents;

        public void RaiseDomainEvent(BaseEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<BaseEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(BaseEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
       
    }
}
