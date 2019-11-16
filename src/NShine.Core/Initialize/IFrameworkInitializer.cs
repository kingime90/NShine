using NShine.Core.Dependency;

namespace NShine.Core.Initialize
{
    /// <summary>
    /// 定义框架初始化器接口。
    /// </summary>
    public interface IFrameworkInitializer
    {
        /// <summary>
        /// 开始初始化框架。
        /// </summary>
        /// <param name="iocBuilder">构建依赖注入映射接口。</param>
        void Initialize(IIocBuilder iocBuilder);
    }
}
