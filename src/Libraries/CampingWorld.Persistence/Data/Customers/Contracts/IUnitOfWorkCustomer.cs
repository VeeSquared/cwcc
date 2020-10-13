using CampingWorld.Persistence.Repositories.Customers;
using System;


namespace CampingWorld.Persistence.Data.Customers
{
    public interface IUnitOfWorkCustomer : IDisposable
    {
        ICustomerRepository Customers { get; }
        int Commit();
    }
}
