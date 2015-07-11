using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GPMS.Core.Entities;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;

namespace GPMS.Core.Services
{
    public class ServiceBase<TEntity, TPrimaryKey>:IServiceBase<TEntity,TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
        where TPrimaryKey : new()
    {
        protected IBaseRepository<TEntity,TPrimaryKey> Repository;

        public long Save(TEntity entity)
        {
            return Repository.Save(entity);
        }

        public bool Update(TEntity entity)
        {
            return Repository.Update(entity);
        }
         

        public TEntity GetEntityById(TPrimaryKey id)
        {
            return Repository.GetEntityById(id);
        }

        public TEntity GetEntityByAction(Expression<Func<TEntity, bool>> func)
        {
            return Repository.GetEntityByAction(func);
        }

        public IList<TEntity> FindAllEntityList()
        {
            return Repository.FindAllEntityList();
        }

        public IList<TEntity> FindAllEntityListByAction(Expression<Func<TEntity, bool>> func)
        {
            return Repository.FindAllEntityListByAction(func);
        }




        public bool Delete(TEntity entity, bool isPhysicsDelete = false)
        {
            return Repository.Delete(entity, isPhysicsDelete);
        }

        public bool Delete(TPrimaryKey id, bool isPhysicsDelete = false)
        {
            return Repository.Delete(id, isPhysicsDelete);
        }
    }
}
