using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WmsSystem.Domain.Interfaces.Services.Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int? id);

        IEnumerable<TEntity> GetAll();

        DbContext GetContext();

        IEnumerable<TEntity> GetAll(string[] includes);

        IEnumerable<TEntity> GetAllAsNotracking(Func<TEntity, bool> predicate);

        TEntity FindAsNotracking(Predicate<TEntity> predicate);

        TEntity FindAsNotracking(Predicate<TEntity> predicate, string[] includes);

        void Update(TEntity oldObj, TEntity obj);

        void Update(Expression<Func<TEntity, bool>> filter, ICollection<object> available, ICollection<object> obj, string propertyName);

        void Remove(TEntity obj);

        void Detach(TEntity obj);

        void Dispose();
    }
}
