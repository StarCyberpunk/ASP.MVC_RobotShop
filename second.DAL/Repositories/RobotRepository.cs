using Microsoft.EntityFrameworkCore;
using second.DAL.Interfaces;
using second.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second.DAL.Repositories
{
    public class RobotRepository : IRobotRepository
    {
        private readonly ApplicationDbContext appDbCon;
        public RobotRepository(ApplicationDbContext a)
        {
            appDbCon = a;
        }
        public bool Create(Robot entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Robot entity)
        {
            throw new NotImplementedException();
        }

        public Robot Get(int id)
        {
            throw new NotImplementedException();
        }

        public Robot GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Robot> Select()
        {
            return (IEnumerable<Robot>)appDbCon.Robot.ToList();
        }
    }
}
