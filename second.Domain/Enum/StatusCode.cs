using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second.Domain.Enum
{
    public enum  StatusCode
    {
        OK=200,
        InternalServerError=500,
        ErrorDB=0,
        NotFound=404
    }
}
