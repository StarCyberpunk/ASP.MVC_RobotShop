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
    public class OrderRepository:IBaseRepository<Order>
    {
        private readonly ApplicationDbContext appDbCon;
        public OrderRepository(ApplicationDbContext a)
        {
            appDbCon = a;
        }

        public async Task<bool> Create(Order entity)
        {
            await appDbCon.Orders.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Order entity)
        {
            appDbCon.Orders.Remove(entity);
            appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<Order> Get(int id)
        {
            return await appDbCon.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Order> Select()
        {
            return  appDbCon.Orders;
        }

        public async Task<Order> Update(Order entity)
        {
            appDbCon.Update(entity);
            appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
