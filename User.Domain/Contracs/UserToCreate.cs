using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;

namespace User.Domain.Contracs
{
    public class UserToCreate
    {
        public UserToCreate(Domain.Entities.User user)
        {

        }
        public Domain.Entities.User User { get; set; }
    }
}
