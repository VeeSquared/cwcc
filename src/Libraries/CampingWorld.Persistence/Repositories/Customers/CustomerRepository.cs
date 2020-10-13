using CampingWorld.Domain.Models;
using CampingWorld.Persistence.Data.Customers;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingWorld.Persistence.Repositories.Customers
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        protected new CustomerContext Context => base.Context as CustomerContext;

        public CustomerRepository(CustomerContext context) : base(context)
        {
        }
        public async Task<List<Customer>> GetAsync()
        {
            return await Context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await Context.Customers.Where(m => m.CustomerID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var customer = await Context.Customers.Where(m => m.CustomerID == id).FirstOrDefaultAsync();
            if (customer == null)
            {
                return false;
            }
            Context.Customers.Remove(customer);
            var save = await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddItemAsync(Customer customer)
        {
            Context.Customers.Add(customer);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateByIdAsync(Customer customer)
        {
            var item = Context.Customers.Where(m => m.CustomerID == customer.CustomerID).FirstOrDefault();

            if (item == null)
            {
                return false;
            }

            item.CustomerID = customer.CustomerID;
            item.FirstName = customer.FirstName;
            item.LastName = customer.LastName;

            Context.Customers.Update(item);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
