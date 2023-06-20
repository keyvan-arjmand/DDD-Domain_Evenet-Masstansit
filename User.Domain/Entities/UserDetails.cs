using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;

namespace User.Domain.Entities
{
    public class UserDetails : EntityBase
    {
        public UserDetails(string? address)
        {
            Address = address;
        }
        public string? Address { get; set; }
    }
}
