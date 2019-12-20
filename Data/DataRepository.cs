using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatSportsTechnicalProject.Data
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly PlayersContext _context;

        public DataRepository(PlayersContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> SaveAsync(T entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }
    }

    public class DataRepository2<U> : IDataRepository2<U> where U : class
    {
        private readonly SessionsContext _context2;

        public DataRepository2(SessionsContext context2)
        {
            _context2 = context2;
        }

        public void Add(U entity)
        {
            _context2.Set<U>().Add(entity);
        }

        public void Update(U entity)
        {
            _context2.Set<U>().Update(entity);
        }

        public void Delete(U entity)
        {
            _context2.Set<U>().Remove(entity);
        }

        public async Task<U> SaveAsync(U entity)
        {
            await _context2.SaveChangesAsync();
            return entity;
        }
    }

    public class DataRepository3<V> : IDataRepository3<V> where V : class
    {
        private readonly PositionsContext _context3;

        public DataRepository3(PositionsContext context3)
        {
            _context3 = context3;
        }

        public void Add(V entity)
        {
            _context3.Set<V>().Add(entity);
        }

        public void Update(V entity)
        {
            _context3.Set<V>().Update(entity);
        }

        public void Delete(V entity)
        {
            _context3.Set<V>().Remove(entity);
        }

        public async Task<V> SaveAsync(V entity)
        {
            await _context3.SaveChangesAsync();
            return entity;
        }
    }
}
