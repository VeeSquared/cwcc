using CampingWorld.Persistence.Repositories.Orders;
using System;


namespace CampingWorld.Persistence.Data.Orders
{
    public interface IUnitOfWorkOrderLine : IDisposable
    {
        IOrderLineRepository OrderLines { get; }
        int Commit();
    }
}
