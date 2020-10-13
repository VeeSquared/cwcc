using CampingWorld.Domain.Models;
using CampingWorld.Persistence.Data.Products;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingWorld.Persistence.Repositories.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected new ProductContext Context => base.Context as ProductContext;

        public ProductRepository(ProductContext context) : base(context)
        {
        }
        public async Task<List<Product>> GetAsync()
        {
            return await Context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await Context.Products.Where(m => m.ProductID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var product = await Context.Products.Where(m => m.ProductID == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return false;
            }
            Context.Products.Remove(product);
            var save = await Context.SaveChangesAsync();
            return true;  
        }

        public async Task<bool> AddItemAsync(Product product)
        {
            Context.Products.Add(product);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateByIdAsync(Product product)
        {
            var item = Context.Products.Where(m => m.ProductID == product.ProductID).FirstOrDefault();

            if (item == null)
            {
                return false;
            }

            item.Name = product.Name;
            item.Price = product.Price;
            item.Cost = product.Cost;

            Context.Products.Update(item);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
