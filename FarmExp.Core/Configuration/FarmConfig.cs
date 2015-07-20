using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;

namespace FarmExp.Core
{
    /// <summary>
    /// 应用配置Config
    /// </summary>
   public class FarmConfig:IConfigurationSectionHandler
    {
        /// <summary>
        /// 创建Config
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public object Create(object parent,object configContext,XmlNode section)
        {
            var config = new FarmConfig();
            var dynamicDiscoveryNode = section.SelectSingleNode("DynamicDiscovery");
            if (dynamicDiscoveryNode != null && dynamicDiscoveryNode.Attributes != null)
            {
                var attribute = dynamicDiscoveryNode.Attributes["Enabled"];
                if (attribute != null)
                    config.DynamicDiscovery = Convert.ToBoolean(attribute.Value);
            }

            var engineNode = section.SelectSingleNode("Engine");
            if (engineNode != null && engineNode.Attributes != null)
            {
                var attribute = engineNode.Attributes["Type"];
                if (attribute != null)
                    config.EngineType = attribute.Value;
            }

            var startupNode = section.SelectSingleNode("Startup");
            if (startupNode != null && startupNode.Attributes != null)
            {
                var attribute = startupNode.Attributes["IgnoreStartupTasks"];
                if (attribute != null)
                    config.IgnoreStartupTasks = Convert.ToBoolean(attribute.Value);
            }

            var themeNode = section.SelectSingleNode("Themes");
            var userAgentStringsNode = section.SelectSingleNode("UserAgentStrings");
            if (userAgentStringsNode != null && userAgentStringsNode.Attributes != null)
            {
                var attribute = userAgentStringsNode.Attributes["databasePath"];
                if (attribute != null)
                    config.UserAgentStringsPath = attribute.Value;
            }

            return config;
        }
        /// <summary>
        /// 是否允许动态加载
        /// </summary>
        public bool DynamicDiscovery { get; private set; }

        /// <summary>
        /// EngineType
        /// </summary>
        public string EngineType { get; private set; }
        /// <summary>
        /// 是否忽略开始任务
        /// </summary>
        public bool IgnoreStartupTasks { get; private set; }

        /// <summary>
        /// 用户配置路径
        /// </summary>
        public string UserAgentStringsPath { get; private set; }
    }
}
