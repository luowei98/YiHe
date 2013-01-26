using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace YiHe.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly IDbSet<T> dbset;
        private YiHeDataContex dataContext;

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory { get; private set; }

        protected YiHeDataContex DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }

        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public virtual IEnumerable<T> GetManyTopBy(Expression<Func<T, long>> which, int count)
        {
            return dbset.OrderBy(which).Take(count).ToList();
        }

        public virtual IEnumerable<T> GetManyLastBy(Expression<Func<T, long>> which, int count)
        {
            return dbset.OrderByDescending(which).Take(count).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault();
        }

        public T GetTopBy(Expression<Func<T, long>> which)
        {
            return dbset.OrderBy(which).FirstOrDefault();
        }

        public T GetLastBy(Expression<Func<T, long>> which)
        {
            return dbset.OrderByDescending(which).FirstOrDefault();
        }
    }
}