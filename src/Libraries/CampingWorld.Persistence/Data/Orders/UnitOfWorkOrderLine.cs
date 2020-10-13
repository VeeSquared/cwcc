using System;
using System.Collections.Generic;
using System.Text;
using CampingWorld.Persistence.Data.Orders;
using CampingWorld.Persistence.Repositories.Orders;

namespace CampingWorld.Persistence.Data.Orders
{
    public class UnitOfWorkOrderLine : IUnitOfWorkOrderLine
    {
        private readonly OrderContext _context;

        public UnitOfWorkOrderLine(OrderContext context)
        {
            OrderLines = new OrderLineRepository(context);
            _context = context;
        }

        public IOrderLineRepository OrderLines { get; private set; }

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
