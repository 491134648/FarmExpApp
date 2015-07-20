using System;
using System.Collections.Generic;
using System.Linq;
using FarmExp.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Threading.Tasks;

namespace FarmExp.Data.EntityFramework
{
    /// <summary>
    /// EF仓储结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class EfRepository<T>:IRepository<T> where T:BaseEntity
    {
        #region Fields

        private readonly IDbContext context;
        private IDbSet<T> _entities;

        #endregion

        #region Ctor

        /// <summary>
        /// EF仓储构造器
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(IDbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 依据唯一值获得一个T对象
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(object id)
        {
            //see some suggested performance optimization (not tested)
            //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 插入一个T实体
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="saveChange">是否异步提交</param>
        public virtual int Insert(T entity, bool saveChange)
        {
            try
            {
                if (entity == null)
                    return 0;
                this.Entities.Add(entity);
                if(saveChange)
                {
                  return  this.context.SaveChangeToDb();
                }
                else
                {
                    this.context.SaveChangeToDbAsync();
                    return 1;
                }
               
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                var fail = new Exception(msg, dbEx);
            }
            return -1;
        }

        /// <summary>
        /// 插入实体枚举
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <param name="saveChange">是否异步提交</param>
        public virtual int Insert(IEnumerable<T> entities, bool saveChange)
        {
            try
            {
                if (entities == null)
                    return 0;

                foreach (var entity in entities)
                    this.Entities.Add(entity);
                if(saveChange)
                {
                    return this.context.SaveChangeToDb();
                }
                else
                {
                    this.context.SaveChangeToDbAsync();
                    return 1;
                }
                
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                var fail = new Exception(msg, dbEx);
            }
            return -1;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="saveChange">是否异步提交</param>
        public virtual int Update(T entity, bool saveChange)
        {
            try
            {
                if (entity == null)
                    return 0;
                this.context.Modified<T>(entity);
                if(saveChange)
                {
                    return this.context.SaveChangeToDb();
                }
                else
                {
                    this.context.SaveChangeToDbAsync();
                    return 1;
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                var fail = new Exception(msg, dbEx);
            }
            return -1;
        }

        /// <summary>
        /// 更新实体枚举
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <param name="saveChange">是否异步提交</param>
        public virtual int Update(IEnumerable<T> entities,bool saveChange)
        {
            try
            {
                if (entities == null)
                    return 0;
                foreach(T item in entities)
                {
                    this.context.Modified<T>(item);
                }
                if(saveChange)
                {
                    return this.context.SaveChangeToDb();
                }
                else
                {
                    this.context.SaveChangeToDbAsync();
                    return 1;
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
            }
            return -1;
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="saveChange">是否异步提交</param>
        public virtual int Delete(T entity,bool saveChange=false)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);
                if (saveChange)
                {
                   return this.context.SaveChangeToDb();
                }
                else
                {
                    this.context.SaveChangeToDbAsync();
                    return 1;
                } 
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
            }
            return -1;
        }

        /// <summary>
        /// 删除实体枚举
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <param name="saveChange">是否异步提交</param>
        public virtual int Delete(IEnumerable<T> entities,bool saveChange = false)
        {
            try
            {
                if (entities == null)
                    return 0;

                foreach (var entity in entities)
                    this.Entities.Remove(entity);
                if (saveChange)
                {
                    return this.context.SaveChangeToDb();
                }
                else
                {
                    this.context.SaveChangeToDbAsync();
                    return 1;
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
            }
            return -1;
        }
        /// <summary>
        /// 提交更改
        /// </summary>
        /// <returns></returns>
       public virtual int SaveChangeToDb()
        {
            return context.SaveChangeToDb();
        }
        /// <summary>
        /// 异步提交更改
        /// </summary>
        /// <returns></returns>
        public virtual Task<int> SaveChangeToDbAsync()
        {
            return context.SaveChangeToDbAsync();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = context.Set<T>();
                return _entities;
            }
        }

        #endregion
    }
}
