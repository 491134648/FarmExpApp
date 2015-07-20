using FarmExp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmExp.Data.EntityFramework
{
    /// <summary>
    /// 仓储接口
    /// </summary>
   public interface IRepository<T> where T:BaseEntity
    {
        /// <summary>
        /// 依据唯一标识获得T对象
        /// </summary>
        /// <param name="id">唯一对象</param>
        /// <returns>Entity</returns>
        T GetById(object id);

        /// <summary>
        /// 插入一个实体
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="saveChange">是否立即提交</param>
        int Insert(T entity,bool saveChange);

        /// <summary>
        /// 插入实体枚举
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <param name="saveChange">是否立即提交</param>
        int Insert(IEnumerable<T> entities,bool saveChange);

        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="saveChange">是否立即提交</param>
        int Update(T entity,bool saveChange);

        /// <summary>
        /// 更新实体枚举
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <param name="saveChange">是否立即提交</param>
        int Update(IEnumerable<T> entities,bool saveChange);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        int Delete(T entity, bool saveChange);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        int Delete(IEnumerable<T> entities, bool saveChange);

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
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }
    }
}
