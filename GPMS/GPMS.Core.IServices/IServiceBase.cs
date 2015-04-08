using System;
using System.Collections.Generic;

namespace GPMS.Core.IServices
{
    public interface IServiceBase<T> where T : class
    {
        long Save(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(long id);
        T GetEntityById(long id);
        T GetEntityByAction(System.Linq.Expressions.Expression<Func<T, bool>> func);
        IList<T> FindAllEntityList();
        IList<T> FindAllEntityListByAction(System.Linq.Expressions.Expression<Func<T, bool>> func);

    }
}
