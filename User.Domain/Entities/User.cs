using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;
using User.Domain.Event;

namespace User.Domain.Entities
{
    public class User : EntityBase
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }

    }
}
