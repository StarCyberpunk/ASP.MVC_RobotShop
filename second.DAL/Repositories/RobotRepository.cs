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
    public class RobotRepository : IBaseRepository<Robot>
    {
        private readonly ApplicationDbContext appDbCon;
        public RobotRepository(ApplicationDbContext a)
        {
            appDbCon = a;
        }
        public async Task< bool> Create(Robot entity)
        {
            await appDbCon.Robot.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Robot entity)
        {
            appDbCon.Robot.Remove(entity);
            appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<Robot> Get(int id)
        {
            return await appDbCon.Robot.FirstOrDefaultAsync(x => x.Id == id);
        }

        

        public IQueryable<Robot> Select()
        {
            return  appDbCon.Robot;
        }

        public async Task<Robot> Update(Robot entity)
        {
            appDbCon.Update(entity);
            appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
