using CampingWorld.Domain.Models;
using CampingWorld.Persistence.Data.Orders;
using CampingWorld.Persistence.Repositories.Orders;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingWorld.Persistence.Repositories.Orders
{
    public class OrderLineRepository : Repository<OrderLine>, IOrderLineRepository
    {
        protected new OrderContext Context => base.Context as OrderContext;

        public OrderLineRepository(OrderContext context) : base(context)
        {
        }
        public async Task<List<OrderLine>> GetAsync()
        {
            return await Context.OrderLines.AsNoTracking().ToListAsync();
        }

        public async Task<OrderLine> GetByIdAsync(int id)
        {
            return await Context.OrderLines.Where(m => m.OrderLineID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var OrderLine = await Context.OrderLines.Where(m => m.OrderLineID == id).FirstOrDefaultAsync();
            if (OrderLine == null)
            {
                return false;
            }
            Context.OrderLines.Remove(OrderLine);
            var save = await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddItemAsync(OrderLine orderLine)
        {
            Context.OrderLines.Add(orderLine);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateByIdAsync(OrderLine orderLine)
        {
            var item = Context.OrderLines.Where(m => m.OrderLineID == orderLine.OrderLineID).FirstOrDefault();

            if (item == null)
            {
                return false;
            }

            item.OrderLineID = orderLine.OrderLineID;
            item.ProductID = orderLine.ProductID;
            item.Quantity = orderLine.Quantity;
            item.OrderID = orderLine.OrderID;

            Context.OrderLines.Update(item);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<List<OrderLine>> GetOrderLinesByOrderIdAsync(int orderID)
        {
            return await Context.OrderLines.Where(m => m.OrderID == orderID).AsNoTracking().ToListAsync();
        }
    }
}
