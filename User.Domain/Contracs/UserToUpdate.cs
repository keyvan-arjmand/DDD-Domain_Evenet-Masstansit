using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Contracs
{
    public class UserToUpdate
    {
        public UserToUpdate(Domain.Entities.User user)
        {

        }
        public Domain.Entities.User User { get; set; }
    }
}
