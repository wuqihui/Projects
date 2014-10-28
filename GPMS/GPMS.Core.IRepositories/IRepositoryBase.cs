using System;
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
        T GetEntityByAction(System.Linq.Expressions.Expression<Func<T,bool>> func);
        IList<T> FindAllEntityList();
        IList<T> FindAllEntityListByAction(System.Linq.Expressions.Expression<Func<T, bool>> func);
    }
}
