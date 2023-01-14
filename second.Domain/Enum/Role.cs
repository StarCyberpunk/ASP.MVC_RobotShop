using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace second.Domain.Enum
{
    public enum Role
    {
        [Display(Name = "Админ")]
        Admin = 0,
        [Display(Name = "Пользователь")]
        User = 1,
        
    }
}
