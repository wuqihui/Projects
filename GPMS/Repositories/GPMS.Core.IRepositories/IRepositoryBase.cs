using System;
using System.Collections.Generic;
using GPMS.Core.Entities;

namespace GPMS.Core.IRepositories
{
    public interface IBaseRepository<TEntity, in TPrimaryKey>
        where TEntity : BaseEntity<TPrimaryKey>
        where TPrimaryKey : new()
    {
        /// <summary>
        /// 保存对象
        /// </summary>
        /// <param name="entity">需要保存的对象</param>
        /// <returns>保存是否成功</returns>
        long Save(TEntity entity);
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="entity">需要更新的对象</param>
        /// <returns>是否更新成功</returns>
        bool Update(TEntity entity);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">需要删除的对象</param>
        /// <param name="isPhysicsDelete">是否真的物理删除，否则只把状态置为删除状态</param>
        /// <returns>是否删除成功</returns>
        bool Delete(TEntity entity,bool isPhysicsDelete=false);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="id">删除对象的id</param>
        /// <param name="isPhysicsDelete">是否真的物理删除，否则只把状态置为删除状态</param>
        /// <returns></returns>
        bool Delete(TPrimaryKey id, bool isPhysicsDelete = false);
        /// <summary>
        /// 获取对象,根据ID
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns></returns>
        TEntity GetEntityById(TPrimaryKey id);

        TEntity GetEntityByAction(System.Linq.Expressions.Expression<Func<TEntity, bool>> func);
        IList<TEntity> FindAllEntityList();

        IList<TEntity> FindAllEntityListByAction(System.Linq.Expressions.Expression<Func<TEntity, bool>> func);
    }
}
