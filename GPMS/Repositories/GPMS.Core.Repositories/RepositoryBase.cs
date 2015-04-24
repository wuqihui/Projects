using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GPMS.Core.IRepositories;
using NHibernate;
using NHibernate.Linq;

namespace GPMS.Core.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ISession _session;
        public long Save(T entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    var newId = (long)_session.Save(entity);
                    _session.Flush();
                    transaction.Commit();
                    return newId;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return 0;
                }
            }
        }

        public bool Update(T entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Update(entity);
                    _session.Flush();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool Delete(T entity)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(entity);
                    _session.Flush();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool Delete(long id)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(GetEntityByID(id));
                    _session.Flush();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public T GetEntityByID(long id)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    object returnEntity = _session.Get<T>(id);
                    _session.Flush();
                    transaction.Commit();
                    return (T)returnEntity;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public T GetEntityByAction(Expression<Func<T, bool>> func)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    object returnEntity = _session.Query<T>().FirstOrDefault(func);
                    _session.Flush();
                    transaction.Commit();
                    return (T)returnEntity;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public IList<T> FindAllEntityList()
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    object returnEntityList = _session.Query<T>().ToList();
                    _session.Flush();
                    transaction.Commit();
                    return (IList<T>)returnEntityList;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public IList<T> FindAllEntityListByAction(Expression<Func<T, bool>> func)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    object returnEntityList = _session.Query<T>().Where(func).ToList();
                    _session.Flush();
                    transaction.Commit();
                    return (IList<T>)returnEntityList;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
