using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using WmsSystem.Domain.Interfaces.Repositories;
using WmsSystem.Repository.Context;

namespace WmsSystem.Repository.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected WmsContext dbContext;

        public RepositoryBase()
        {
            dbContext = new WmsContext();
        }

        public void Add(TEntity obj)
        {
            GetContext().Set<TEntity>().Add(obj);
            GetContext().SaveChanges();
        }

        public void Dispose()
        {
            GetContext().Dispose();
        }

        public IEnumerable<TEntity> GetAll(string[] includes)
        {
            IQueryable<TEntity> query = null;
            query = GetContext().Set<TEntity>();

            foreach (string i in includes)
            {
                query = query.Include(i);
            }

            return query.ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetContext().Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllAsNotracking(Func<TEntity, bool> predicate)
        {
            return GetContext().Set<TEntity>().AsNoTracking().Where(predicate).ToList<TEntity>();
        }

        public TEntity FindAsNotracking(Predicate<TEntity> predicate)
        {
            return GetContext().Set<TEntity>().AsNoTracking<TEntity>().ToList<TEntity>().Find(predicate);
        }

        public TEntity GetById(int? id)
        {
            return GetContext().Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            GetContext().Set<TEntity>().Remove(obj);
            GetContext().SaveChanges();

        }

        public void Update(TEntity oldObj, TEntity obj)
        {
            GetContext().Entry(oldObj).State = EntityState.Modified;
            GetContext().Entry(oldObj).CurrentValues.SetValues(obj);
            GetContext().SaveChanges();
        }

        public void Update(Expression<Func<TEntity, bool>> filter, ICollection<object> available, ICollection<object> obj, string propertyName)
        {
            var type = obj.GetType().GetGenericArguments()[0];

            var previous = GetContext().Set<TEntity>().Include(propertyName).FirstOrDefault(filter);
            var values = CreateList(type);
            GetContext().Entry(previous).Collection(propertyName).CurrentValue = values;
            GetContext().SaveChanges();


        }

        public IList CreateList(Type type)
        {
            var genericList = typeof(List<>).MakeGenericType(type);
            return (IList)Activator.CreateInstance(genericList);
        }



        public void SaveChanges()
        {
            GetContext().SaveChanges();
        }

        public void Detach(TEntity obj)
        {
            this.GetContext().Entry(obj).State = EntityState.Detached;
        }

        public bool IsDisposed(DbContext context)
        {
            var result = true;

            var typeDbContext = typeof(DbContext);            
            var typeInternalContext = typeDbContext.Assembly.GetType("Microsoft.EntityFrameworkCore.DbContext");

            var fi_InternalContext = typeDbContext.GetField("_internalContext", BindingFlags.NonPublic | BindingFlags.Instance);
            var pi_IsDisposed = typeInternalContext.GetProperty("IsDisposed");

            //var ic = fi_InternalContext.GetValue(context);

            //if (ic != null)
            //{
            //    result = (bool)pi_IsDisposed.GetValue(ic);
            //}

            return result;
        }

        DbContext IRepositoryBase<TEntity>.GetContext()
        {
            return GetContext();
        }

        public TEntity FindAsNotracking(Predicate<TEntity> predicate, string[] includes)
        {
            var Queryable = GetContext().Set<TEntity>().AsNoTracking();

            foreach (string i in includes)
            {
                Queryable = Queryable.Include(i);
            }

            return Queryable.ToList().Find(predicate);
        }

        public WmsContext GetContext()
        {
            return (IsDisposed(dbContext)) ? new WmsContext() : dbContext;
        }
    }
}
