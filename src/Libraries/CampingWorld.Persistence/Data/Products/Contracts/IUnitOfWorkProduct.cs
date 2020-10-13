using CampingWorld.Persistence.Repositories.Products;
using System;


namespace CampingWorld.Persistence.Data.Products
{
    public interface IUnitOfWorkProduct : IDisposable
    {
        IProductRepository Products { get; }
        int Commit();
    }
}
