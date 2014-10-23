using System.Collections.Generic;

namespace GPMS.Core.IRepositories
{
    public interface IRepositoryBase<T> where T : class
    {
        long Save(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(long id);
        T GetEntityByID(long id);
        IList<T> FindAllEntityList();
    }
}
