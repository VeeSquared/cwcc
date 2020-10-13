using CampingWorld.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampingWorld.Persistence.Repositories.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetAsync();
        Task<Order> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> AddItemAsync(Order order);
        Task<bool> UpdateByIdAsync(Order order);
    }
}
