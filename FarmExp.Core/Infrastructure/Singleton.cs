using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Core
{
    /// <summary>
    /// 泛型单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class Singleton<T>:Singleton
    {
        static T instance;

        /// <summary>The singleton instance for the specified type T. Only one instance (at the time) of this object for each type of T.</summary>
        public static T Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }
    /// <summary>
    /// 某类型单例List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonList<T> : Singleton<IList<T>>
    {
        static SingletonList()
        {
            Singleton<IList<T>>.Instance = new List<T>();
        }

        /// <summary>The singleton instance for the specified type T. Only one instance (at the time) of this list for each type of T.</summary>
        public new static IList<T> Instance
        {
            get { return Singleton<IList<T>>.Instance; }
        }
    }
    /// <summary>
    /// 某类型单例
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>>
    {
        static SingletonDictionary()
        {
            Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
        }

        /// <summary>The singleton instance for the specified type T. Only one instance (at the time) of this dictionary for each type of T.</summary>
        public new static IDictionary<TKey, TValue> Instance
        {
            get { return Singleton<Dictionary<TKey, TValue>>.Instance; }
        }
    }
    /// <summary>
    /// 单例
    /// </summary>
    public class Singleton
    {
        static Singleton()
        {
            allSingletons = new Dictionary<Type, object>();
        }

        static readonly IDictionary<Type, object> allSingletons;

        /// <summary>Dictionary of type to singleton instances.</summary>
        public static IDictionary<Type, object> AllSingletons
        {
            get { return allSingletons; }
        }
    }
}
