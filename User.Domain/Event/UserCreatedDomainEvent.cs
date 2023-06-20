﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;
using User.Domain.Entities;
using User.Domain.ValueObjects;

namespace User.Domain.Event
{
    public class UserCreatedDomainEvent : BaseEvent
    {
        public PhoneNumber PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public UserDetails Details { get; set; }
    }
}
