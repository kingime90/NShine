using System;

namespace NShine.Core.Dependency
{
    /// <summary>
    /// 定义构建依赖注入映射接口。
    /// </summary>
    public interface IIocBuilder
    {
        /// <summary>
        /// 获取 服务提供者。
        /// </summary>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 开始构建依赖注入映射。
        /// </summary>
        void Build();
    }
}
