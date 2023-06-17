using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;

namespace User.Domain.Contracs
{
    public static class UserMap
    {
        public static UserToCreate CreateMap(Domain.Entities.User user)
        {
            return new UserToCreate(user);
        }
        public static UserToCreate UpdateMap(Domain.Entities.User user)
        {
            return new UserToCreate(user);
        }
        public static UserToCreate DeleteMap(Domain.Entities.User user)
        {
            return new UserToCreate(user);
        }
    }
}
