﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Entity.Concrete.identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
