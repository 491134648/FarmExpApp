using Autofac;

namespace FarmExp.Core
{
    /// <summary>
    /// 依赖注入接口
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 注入指定类型往指定DI容器
        /// </summary>
        /// <param name="builder">DI容器</param>
        /// <param name="typeFinder">类型</param>
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}
