using FarmExp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmExp.Data.Interface
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {

        /// <summary>
        /// 依据唯一标识获得T对象
        /// </summary>
        /// <param name="id">唯一对象</param>
        /// <returns>Entity</returns>
        TEntity GetById(object id);

        /// <summary>
        /// 插入一个实体
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="saveChange">是否立即提交</param>
        int Insert(TEntity entity, bool saveChange);

        /// <summary>
        /// 插入实体枚举
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <param name="saveChange">是否立即提交</param>
        int Insert(IEnumerable<TEntity> entities, bool saveChange);

        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="saveChange">是否立即提交</param>
        int Update(TEntity entity, bool saveChange);

        /// <summary>
        /// 更新实体枚举
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <param name="saveChange">是否立即提交</param>
        int Update(IEnumerable<TEntity> entities, bool saveChange);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        int Delete(TEntity entity, bool saveChange);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        int Delete(IEnumerable<TEntity> entities, bool saveChange);

        /// <summary>
        /// 提交更改
        /// </summary>
        /// <returns></returns>
        int SaveChangeToDb();
        /// <summary>
        /// 异步提交更改
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangeToDbAsync();
        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }
    }
}
