using System;
using System.Collections.Generic;
using System.Text;

namespace CampingWorld.Persistence.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetBy(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(IEnumerable<T> spec);
        int Count(IEnumerable<T> spec);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
