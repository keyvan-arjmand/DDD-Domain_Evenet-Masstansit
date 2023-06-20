using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;
using User.Domain.Event;
using User.Domain.ValueObjects;

namespace User.Domain.Entities
{
    public class User : AggregateRoot
    {
        public User()
        {
        }
        public User(PhoneNumber phoneNumber, string name, string lastName, string userName, string passWord)
        {
            PhoneNumber = phoneNumber;
            Name = name;
            LastName = lastName;
            UserName = userName;
            PassWord = passWord;
        }

        public PhoneNumber PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public UserDetails Details { get; set; }
     

    }
}
