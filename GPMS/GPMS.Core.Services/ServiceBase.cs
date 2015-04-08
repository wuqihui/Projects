using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;

namespace GPMS.Core.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected IRepositoryBase<T> Repository;

        public long Save(T entity)
        {
            return Repository.Save(entity);
        }

        public bool Update(T entity)
        {
            return Repository.Update(entity);
        }

        public bool Delete(T entity)
        {
            return Repository.Delete(entity);
        }

        public bool Delete(long id)
        {
            return Repository.Delete(id);
        }

        public T GetEntityById(long id)
        {
            return Repository.GetEntityByID(id);
        }

        public T GetEntityByAction(Expression<Func<T, bool>> func)
        {
            return Repository.GetEntityByAction(func);
        }

        public IList<T> FindAllEntityList()
        {
            return Repository.FindAllEntityList();
        }

        public IList<T> FindAllEntityListByAction(Expression<Func<T, bool>> func)
        {
            return Repository.FindAllEntityListByAction(func);
        }
    }
}
