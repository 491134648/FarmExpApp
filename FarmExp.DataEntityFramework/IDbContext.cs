using System.Collections.Generic;
using System.Data;
using FarmExp.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FarmExp.Data.EntityFramework
{
    /// <summary>
    /// 数据库上下文接口
    /// </summary>
   public interface IDbContext
    {
       /// <summary>
       /// 设定实体
       /// </summary>
       /// <typeparam name="TEntity"></typeparam>
       /// <returns></returns>
       IDbSet<TEntity> Set<TEntity>() where TEntity :BaseEntity;
       void Modified<TEntity>(TEntity item) where TEntity : BaseEntity;
       void Modified<TEntity>(IEnumerable<TEntity> items) where TEntity : BaseEntity;
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
        /// 执行存储过程
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
           where TEntity : BaseEntity, new();
        /// <summary>
        /// 创建一个数据库查询
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
       /// <summary>
       /// 执行Sql
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="doNotEnsureTransaction"></param>
       /// <param name="timeout"></param>
       /// <param name="parameters"></param>
       /// <returns></returns>
       int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);
   }
}
