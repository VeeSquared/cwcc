using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CampingWorld.Persistence.Repositories;
using System;

namespace Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context;
        protected DbContext Context => _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {            
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }

        public IEnumerable<T> Find(IEnumerable<T> entities)
        {
            return entities.ToList();
        }

        public int Count(IEnumerable<T> entities)
        {
            return entities.Count();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}