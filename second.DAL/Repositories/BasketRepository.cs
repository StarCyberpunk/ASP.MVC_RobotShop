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
    public class BasketRepository : IBaseRepository<Basket>
    {
        private readonly ApplicationDbContext appDbCon;
        public BasketRepository(ApplicationDbContext a)
        {
            appDbCon = a;
        }
        public async Task<bool> Create(Basket entity)
        {
            await appDbCon.Baskets.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Basket entity)
        {
            appDbCon.Baskets.Remove(entity);
            appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<Basket> Get(int id)
        {
            return await appDbCon.Baskets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Basket> Select()
        {
            return  appDbCon.Baskets;
        }

        public async Task<Basket> Update(Basket entity)
        {
            appDbCon.Update(entity);
            appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
