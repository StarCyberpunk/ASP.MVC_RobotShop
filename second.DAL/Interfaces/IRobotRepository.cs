using second.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second.DAL.Interfaces
{
    public interface IRobotRepository:IBaseRepository<Robot>
    {
        Robot GetByName(string name);
    }
}
