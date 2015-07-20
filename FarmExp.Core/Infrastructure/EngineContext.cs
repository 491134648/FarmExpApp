using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace FarmExp.Core
{
   public class EngineContext
    {
        /// <summary>
        /// 创建EngineContext实例
        /// </summary>
        /// <param name="config">FarmConfi</param>
        /// <returns>IEngine</returns>
        protected static IEngine CreateEngineInstance(FarmConfig config)
        {
            if (config != null && !string.IsNullOrEmpty(config.EngineType))
            {
                var engineType = Type.GetType(config.EngineType);
                if (engineType == null)
                    throw new ConfigurationErrorsException("The type '" + config.EngineType + "' could not be found. Please check the configuration at /configuration/nop/engine[@engineType] or check for missing assemblies.");
                if (!typeof(IEngine).IsAssignableFrom(engineType))
                    throw new ConfigurationErrorsException("The type '" + engineType + "' doesn't implement 'Nop.Core.Infrastructure.IEngine' and cannot be configured in /configuration/nop/engine[@engineType] for that purpose.");
                return Activator.CreateInstance(engineType) as IEngine;
            }
            return new FarmEngine();
        }
        /// <summary>
        /// 初始化IEngine
        /// </summary>
        /// <param name="forceRecreate">是否强制重建</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceRecreate)
        {
            //判断IEngine实例是否为空及是否强制重建
            if (Singleton<IEngine>.Instance == null || forceRecreate)
            {
                var config = ConfigurationManager.GetSection("NopConfig") as FarmConfig;
                Singleton<IEngine>.Instance = CreateEngineInstance(config);
                Singleton<IEngine>.Instance.Initialize(config);
            }
            return Singleton<IEngine>.Instance;
        }
    }
}
