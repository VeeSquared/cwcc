using System;
using System.Collections.Generic;
using System.Text;
using CampingWorld.Persistence.Data.Products;
using CampingWorld.Persistence.Repositories.Products;

namespace CampingWorld.Persistence.Data.Products
{
    public class UnitOfWorkProduct : IUnitOfWorkProduct
    {
        private readonly ProductContext _context;

        public UnitOfWorkProduct(ProductContext context)
        {
            Products = new ProductRepository(context);
            _context = context;
        }

        public IProductRepository Products { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
