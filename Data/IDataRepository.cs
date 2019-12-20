using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatSportsTechnicalProject.Data
{
    public interface IDataRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> SaveAsync(T entity);
    }

    public interface IDataRepository2<U> where U : class
    {
        void Add(U entity);
        void Update(U entity);
        void Delete(U entity);
        Task<U> SaveAsync(U entity);
    }

    public interface IDataRepository3<V> where V : class
    {
        void Add(V entity);
        void Update(V entity);
        void Delete(V entity);
        Task<V> SaveAsync(V entity);
    }
}
