using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using NHibernate;
using NHibernate.Linq;

namespace GPMS.Core.Repositories
{
    public class BaseRepository<TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey>
        where TEntity : BaseEntity<TPrimaryKey>
        where TPrimaryKey : new()
    {
        protected ISession _session;
        public long Save(TEntity entity)
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

        public bool Update(TEntity entity)
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
         

        public TEntity GetEntityById(TPrimaryKey id)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    object returnEntity = _session.Get<TEntity>(id);
                    _session.Flush();
                    transaction.Commit();
                    return (TEntity)returnEntity;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public TEntity GetEntityByAction(Expression<Func<TEntity, bool>> func)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    object returnEntity = _session.Query<TEntity>().FirstOrDefault(func);
                    _session.Flush();
                    transaction.Commit();
                    return (TEntity)returnEntity;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public IList<TEntity> FindAllEntityList()
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    object returnEntityList = _session.Query<TEntity>().ToList();
                    _session.Flush();
                    transaction.Commit();
                    return (IList<TEntity>)returnEntityList;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public IList<TEntity> FindAllEntityListByAction(Expression<Func<TEntity, bool>> func)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    object returnEntityList = _session.Query<TEntity>().Where(func).ToList();
                    _session.Flush();
                    transaction.Commit();
                    return (IList<TEntity>)returnEntityList;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public bool Delete(TEntity entity, bool isPhysicsDelete = false)
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

        public bool Delete(TPrimaryKey id ,bool isPhysicsDelete = false)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(GetEntityById(id));
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
    }
}
