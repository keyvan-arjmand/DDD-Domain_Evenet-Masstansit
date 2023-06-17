using User.Domain.Event;

namespace User.Domain
{
    public class Class1
    {
        public void d()
        {
            Entities.User user = new Entities.User();
            var r = new UserCreatedDomainEvent(new Entities.User { LastName = "dwd" });
            r.User.AddDomainEvent
        }
    }
}