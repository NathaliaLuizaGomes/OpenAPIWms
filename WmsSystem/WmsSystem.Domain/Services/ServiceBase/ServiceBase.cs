using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WmsSystem.Domain.Interfaces.Repositories;
using WmsSystem.Domain.Interfaces.Services.Base;

namespace WmsSystem.Domain.Services.ServiceBase
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _baseServicoRepositorio;


        public ServiceBase(IRepositoryBase<TEntity> baseServico) : base()
        {
            _baseServicoRepositorio = baseServico;
        }


        public void Add(TEntity obj)
        {
            _baseServicoRepositorio.Add(obj);
        }

        public void Dispose()
        {
            _baseServicoRepositorio.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseServicoRepositorio.GetAll();
        }

        public IEnumerable<TEntity> GetAll(string[] includes)
        {
            return _baseServicoRepositorio.GetAll(includes);
        }

        public IEnumerable<TEntity> GetAllAsNotracking(Func<TEntity, bool> predicate)
        {
            return _baseServicoRepositorio.GetAllAsNotracking(predicate);
        }

        public TEntity FindAsNotracking(Predicate<TEntity> predicate)
        {
            return _baseServicoRepositorio.FindAsNotracking(predicate);
        }

        public TEntity GetById(int? id)
        {
            return _baseServicoRepositorio.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _baseServicoRepositorio.Remove(obj);
        }

        public void Update(TEntity oldObj, TEntity obj)
        {
            _baseServicoRepositorio.Update(oldObj, obj);
        }

        public void Update(Expression<Func<TEntity, bool>> filter, ICollection<object> available, ICollection<object> obj, string propertyName)
        {
            _baseServicoRepositorio.Update(filter, available, obj, propertyName);
        }

        public void Detach(TEntity obj)
        {
            _baseServicoRepositorio.Detach(obj);
        }

        public DbContext GetContext()
        {
            return _baseServicoRepositorio.GetContext();
        }

        public TEntity FindAsNotracking(Predicate<TEntity> predicate, string[] includes)
        {
            return _baseServicoRepositorio.FindAsNotracking(predicate, includes);
        }
    }
}
