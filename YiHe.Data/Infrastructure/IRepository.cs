using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace YiHe.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        T GetTopBy(Expression<Func<T, long>> which);
        T GetLastBy(Expression<Func<T, long>> which);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> GetManyTopBy(Expression<Func<T, long>> which, int count);
        IEnumerable<T> GetManyLastBy(Expression<Func<T, long>> which, int count);
    }
}