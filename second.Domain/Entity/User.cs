﻿using second.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second.Domain.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public Role Role { get; set; }
        public Profile Profile { get; set; }
        public Basket Basket { get; set; }
    }
}
