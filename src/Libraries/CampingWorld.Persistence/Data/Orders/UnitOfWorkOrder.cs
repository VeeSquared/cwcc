using System;
using System.Collections.Generic;
using System.Text;
using CampingWorld.Persistence.Data.Orders;
using CampingWorld.Persistence.Repositories.Orders;

namespace CampingWorld.Persistence.Data.Orders
{
    public class UnitOfWorkOrder : IUnitOfWorkOrder
    {
        private readonly OrderContext _context;

        public UnitOfWorkOrder(OrderContext context)
        {
            Orders = new OrderRepository(context);
            _context = context;
        }

        public IOrderRepository Orders { get; private set; }

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
