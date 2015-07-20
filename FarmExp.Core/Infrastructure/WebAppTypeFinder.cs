using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

namespace FarmExp.Core
{
    /// <summary>
    /// 提供当前webApplication的Type信息
    /// </summary>
   public class WebAppTypeFinder: AppDomainTypeFinder
    {
        #region Fields

        private bool _ensureBinFolderAssembliesLoaded = true;//是否动态加载
        private bool _binFolderAssembliesLoaded;

        #endregion

        #region Ctor
        /// <summary>
        /// 实例化WebTypeFinder
        /// </summary>
        /// <param name="config">FarmConfig配置</param>
        public WebAppTypeFinder(FarmConfig config)
        {
            this._ensureBinFolderAssembliesLoaded = config.DynamicDiscovery;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否允许Bin目录动态加载
        /// </summary>
        public bool EnsureBinFolderAssembliesLoaded
        {
            get { return _ensureBinFolderAssembliesLoaded; }
            set { _ensureBinFolderAssembliesLoaded = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 获取当前Application的Bin目录物理路径
        /// </summary>
        /// <returns>当前Application的Bin目录物理路径</returns>
        public virtual string GetBinDirectory()
        {
            if (HostingEnvironment.IsHosted)
            {
                return HttpRuntime.BinDirectory;
            }
            return AppDomain.CurrentDomain.BaseDirectory;
        }
        /// <summary>
        /// 获得程序集List
        /// </summary>
        /// <returns></returns>
        public override IList<Assembly> GetAssemblies()
        {
            if (this.EnsureBinFolderAssembliesLoaded && !_binFolderAssembliesLoaded)
            {
                _binFolderAssembliesLoaded = true;
                string binPath = GetBinDirectory();
                //binPath = _webHelper.MapPath("~/bin");
                LoadMatchingAssemblies(binPath);
            }

            return base.GetAssemblies();
        }

        #endregion
    }
}
