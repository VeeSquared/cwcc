using CampingWorld.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampingWorld.Persistence.Repositories.Orders
{
    public interface IOrderLineRepository : IRepository<OrderLine>
    {
        Task<List<OrderLine>> GetAsync();
        Task<OrderLine> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> AddItemAsync(OrderLine orderLine);
        Task<bool> UpdateByIdAsync(OrderLine orderLine);
        Task<List<OrderLine>> GetOrderLinesByOrderIdAsync(int orderID);
    }
}
