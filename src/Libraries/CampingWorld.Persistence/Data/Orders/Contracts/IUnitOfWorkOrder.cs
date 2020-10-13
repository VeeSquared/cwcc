using CampingWorld.Persistence.Repositories.Orders;
using System;


namespace CampingWorld.Persistence.Data.Orders
{
    public interface IUnitOfWorkOrder : IDisposable
    {
        IOrderRepository Orders { get; }
        int Commit();
    }
}
