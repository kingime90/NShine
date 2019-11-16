using System;

namespace NShine.Core.Dependency
{
    /// <summary>
    /// 依赖注入服务提供者。
    /// </summary>
    public class IocServiceProvider : IServiceProvider
    {
        private readonly IIocResolver _iocResolver;

        /// <summary>
        /// 初始化一个<see cref="IocServiceProvider"/>类型的新实例。
        /// </summary>
        /// <param name="iocResolver">依赖注入解析器接口。</param>
        public IocServiceProvider(IIocResolver iocResolver)
        {
            _iocResolver = iocResolver;
        }

        /// <summary>
        /// 获取指定类型的服务对象。
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return _iocResolver.Resolve(serviceType);
        }
    }
}
