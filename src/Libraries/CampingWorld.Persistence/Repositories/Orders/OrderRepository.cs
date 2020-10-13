using CampingWorld.Domain.Models;
using CampingWorld.Persistence.Data.Orders;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingWorld.Persistence.Repositories.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        protected new OrderContext Context => base.Context as OrderContext;

        public OrderRepository(OrderContext context) : base(context)
        {
        }
        public async Task<List<Order>> GetAsync()
        {
            return await Context.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await Context.Orders.Where(m => m.OrderID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var order = await Context.Orders.Where(m => m.OrderID == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return false;
            }
            Context.Orders.Remove(order);
            var save = await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddItemAsync(Order order)
        {
            Context.Orders.Add(order);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateByIdAsync(Order order)
        {
            var item = Context.Orders.Where(m => m.OrderID == order.OrderID).FirstOrDefault();

            if (item == null)
            {
                return false;
            }

            item.OrderID = order.OrderID;
            item.CustomerID = order.CustomerID;
            item.OrderDate = order.OrderDate;

            Context.Orders.Update(item);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
