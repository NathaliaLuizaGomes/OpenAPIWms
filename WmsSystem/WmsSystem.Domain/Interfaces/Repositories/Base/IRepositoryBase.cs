using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;

namespace WmsSystem.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int? id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(string[] includes);

        TEntity FindAsNotracking(Predicate<TEntity> predicate);

        TEntity FindAsNotracking(Predicate<TEntity> predicate, string[] includes);

        IEnumerable<TEntity> GetAllAsNotracking(Func<TEntity, bool> predicate);

        void Update(TEntity oldObj, TEntity obj);

        void Update(Expression<Func<TEntity, bool>> filter, ICollection<object> available, ICollection<object> obj, string propertyName);

        void Remove(TEntity obj);

        void SaveChanges();

        DbContext GetContext();

        void Detach(TEntity obj);

        void Dispose();
    }
}
