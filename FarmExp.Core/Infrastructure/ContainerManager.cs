using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmExp.Core
{
    /// <summary>
    /// 依赖注入管理者
    /// </summary>
    public class ContainerManager
    {
        private readonly IContainer container;
        public ContainerManager(IContainer _container)
        {
            this.container = _container;
        }
        public virtual IContainer Container
        {
            get { return container; }
        }
        public virtual T Resolve<T>(string key="",ILifetimeScope lifeScope=null) where T:class
        {
            if(lifeScope==null)
            {
                lifeScope = LifeScope();
            }
            if(string.IsNullOrEmpty(key))
            {
                return lifeScope.Resolve<T>();
            }
            return lifeScope.ResolveKeyed<T>(key);
        }
        public virtual object Resolve(Type type,ILifetimeScope lifeScope=null)
        {
            if(lifeScope==null)
            {
                lifeScope = LifeScope();
            }
            return lifeScope.Resolve(type);
        }
        public virtual T[] ResolveAll<T>(string key="",ILifetimeScope lifeScope = null)
        {
            if (lifeScope == null)
            {
                lifeScope = LifeScope();
            }
            if(string.IsNullOrEmpty(key))
            {
                return lifeScope.Resolve<IEnumerable<T>>().ToArray();
            }
            return lifeScope.ResolveKeyed<IEnumerable<T>>(key).ToArray();
        }
        public virtual T ResolveUnRegistered<T>(ILifetimeScope lifeScope=null) where T:class
        {
            return ResolveUnregistered(typeof(T), lifeScope) as T;
        }
        public virtual object ResolveUnregistered(Type type, ILifetimeScope lifeScope = null)
        {
            if (lifeScope == null)
            {
                //no scope specified
                lifeScope = LifeScope();
            }
            var constructors = type.GetConstructors();
            foreach (var constructor in constructors)
            {
                try
                {
                    var parameters = constructor.GetParameters();
                    var parameterInstances = new List<object>();
                    foreach (var parameter in parameters)
                    {
                        var service = Resolve(parameter.ParameterType, lifeScope);
                        if (service == null) throw new FarmException("Unkown dependency");
                        parameterInstances.Add(service);
                    }
                    return Activator.CreateInstance(type, parameterInstances.ToArray());
                }
                catch (FarmException)
                {

                }
            }
            throw new FarmException("No contructor was found that had all the dependencies satisfied.");
        }
        public virtual bool TryResolve(Type serviceType, ILifetimeScope lifeScope, out object instance)
        {
            if (lifeScope == null)
            {
                //no scope specified
                lifeScope = LifeScope();
            }
            return lifeScope.TryResolve(serviceType, out instance);
        }

        public virtual bool IsRegistered(Type serviceType, ILifetimeScope lifeScope = null)
        {
            if (lifeScope == null)
            {
                //no scope specified
                lifeScope = LifeScope();
            }
            return lifeScope.IsRegistered(serviceType);
        }

        public virtual object ResolveOptional(Type serviceType, ILifetimeScope lifeScope = null)
        {
            if (lifeScope == null)
            {
                //no scope specified
                lifeScope = LifeScope();
            }
            return lifeScope.ResolveOptional(serviceType);
        }
        private ILifetimeScope LifeScope()
        {
            try
            {
                if(HttpContext.Current!=null)
                {
                    return AutofacDependencyResolver.Current.RequestLifetimeScope;
                }
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
            catch(Exception)
            {
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
        }
    }
}
