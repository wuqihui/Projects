using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;

namespace GPMS.Core.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected IRepositoryBase<T> _repository;

        public long Save(T entity)
        {
            return _repository.Save(entity);
        }

        public bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public bool Delete(long id)
        {
            return _repository.Delete(id);
        }

        public T GetEntityByID(long id)
        {
            return _repository.GetEntityByID(id);
        }

        public T GetEntityByAction(Expression<Func<T, bool>> func)
        {
            return _repository.GetEntityByAction(func);
        }

        public IList<T> FindAllEntityList()
        {
            return _repository.FindAllEntityList();
        }

        public IList<T> FindAllEntityListByAction(Expression<Func<T, bool>> func)
        {
            return _repository.FindAllEntityListByAction(func);
        }
    }
}
