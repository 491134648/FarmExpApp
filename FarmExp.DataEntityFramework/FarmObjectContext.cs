using System;
using Microsoft.Data.Entity;
using System.Data;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Data.Common;

namespace FarmExp.Data.EntityFramework
{
   public class FarmObjectContext:DbContext,IDbContext
    {
        public FarmObjectContext(string nameOrConnectionString):base(nameOrConnectionString)
        {
     
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToregister = Assembly.GetExecutingAssembly().GetTypes().Where(t=>!string.IsNullOrEmpty(t.Namespace)).Where(t=>t.BaseType!=null&&t.BaseType.IsGenericType&&t.BaseType.GetGenericTypeDefinition()==typeof(FarmEntityConfiguration<>));
            foreach(var type in typesToregister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
       /// <summary>
       /// 附加实体至上下文
      
        protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            //little hack here until Entity Framework really supports stored procedures
            //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
            var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
            if (alreadyAttached == null)
            {
                //attach new entity
                Set<TEntity>().Attach(entity);
                return entity;
            }

            //entity is already loaded
            return alreadyAttached;
        }
       /// <summary>
       /// 创建数据库脚本
       /// </summary>
       /// <returns></returns>
        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
       /// <summary>
       /// 执行存数过程
       /// </summary>
       /// <typeparam name="TEntity"></typeparam>
       /// <param name="commandText"></param>
       /// <param name="parameters"></param>
       /// <returns></returns>
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            //add parameters to command
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if (p == null)
                        throw new Exception("Not support parameter type");

                    commandText += i == 0 ? " " : ", ";

                    commandText += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        //output parameter
                        commandText += " output";
                    }
                }
            }

            var result = this.Database.SqlQuery<TEntity>(commandText, parameters).ToList();
            bool acd = this.Configuration.AutoDetectChangesEnabled;
            try
            {
                this.Configuration.AutoDetectChangesEnabled = false;

                for (int i = 0; i < result.Count; i++)
                    result[i] = AttachEntityToContext(result[i]);
            }
            finally
            {
                this.Configuration.AutoDetectChangesEnabled = acd;
            }

            return result;
        }
       /// <summary>
       /// 执行Sql语句返回Ienumerable对象
       /// </summary>
       /// <typeparam name="TElement"></typeparam>
       /// <param name="sql"></param>
       /// <param name="parameters"></param>
       /// <returns></returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }
       /// <summary>
       /// 执行Sql语句，返回受影响的行数
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="doNotEnsureTransaction"></param>
       /// <param name="timeout"></param>
       /// <param name="parameters"></param>
       /// <returns></returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                //store previous timeout
                previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }

            var transactionalBehavior = doNotEnsureTransaction
                ? TransactionalBehavior.DoNotEnsureTransaction
                : TransactionalBehavior.EnsureTransaction;
            var result = this.Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);

            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
            }

            //return result
            return result;
        }

    }
}
