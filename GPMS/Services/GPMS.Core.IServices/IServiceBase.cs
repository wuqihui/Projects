using System;
using System.Collections.Generic;
using GPMS.Core.Entities;

namespace GPMS.Core.IServices
{
    public interface IServiceBase<TEntity, in TPrimaryKey>
        where TEntity : BaseEntity<TPrimaryKey>
        where TPrimaryKey : new()
    {
        long Save(TEntity entity);
        bool Update(TEntity entity);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">需要删除的对象</param>
        /// <param name="isPhysicsDelete">是否真的物理删除，否则只把状态置为删除状态</param>
        /// <returns>是否删除成功</returns>
        bool Delete(TEntity entity, bool isPhysicsDelete = false);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="id">删除对象的id</param>
        /// <param name="isPhysicsDelete">是否真的物理删除，否则只把状态置为删除状态</param>
        /// <returns></returns>
        bool Delete(TPrimaryKey id, bool isPhysicsDelete = false);
        TEntity GetEntityById(TPrimaryKey id);
        TEntity GetEntityByAction(System.Linq.Expressions.Expression<Func<TEntity, bool>> func);
        IList<TEntity> FindAllEntityList();
        IList<TEntity> FindAllEntityListByAction(System.Linq.Expressions.Expression<Func<TEntity, bool>> func);

    }
}
