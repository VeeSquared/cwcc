using CampingWorld.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampingWorld.Persistence.Repositories.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAsync();
        Task<Product> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> AddItemAsync(Product product);
        Task<bool> UpdateByIdAsync(Product product);
    }
}
