using CampingWorld.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampingWorld.Persistence.Repositories.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> AddItemAsync(Customer customer);
        Task<bool> UpdateByIdAsync(Customer customer);
    }
}
