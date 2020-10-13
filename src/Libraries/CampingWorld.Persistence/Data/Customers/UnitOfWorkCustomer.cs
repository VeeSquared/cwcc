using System;
using System.Collections.Generic;
using System.Text;
using CampingWorld.Persistence.Data.Customers;
using CampingWorld.Persistence.Repositories.Customers;

namespace CampingWorld.Persistence.Data.Customers
{
    public class UnitOfWorkCustomer : IUnitOfWorkCustomer
    {
        private readonly CustomerContext _context;

        public UnitOfWorkCustomer(CustomerContext context)
        {
            Customers = new CustomerRepository(context);
            _context = context;
        }

        public ICustomerRepository Customers { get; private set; }

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
