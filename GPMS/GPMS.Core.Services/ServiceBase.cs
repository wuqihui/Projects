using System.Collections.Generic;
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

        public IList<T> FindAllEntityList()
        {
            return _repository.FindAllEntityList();
        }
    }
}
