using System;
using System.Collections.Generic;

namespace NShine.Core.Dependency
{
    /// <summary>
    /// 定义依赖注入解析器接口。
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// 获取指定服务类型的服务对象。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <returns></returns>
        TService Resolve<TService>() where TService : class;

        /// <summary>
        /// 获取指定服务类型的服务对象。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <returns></returns>
        object Resolve(Type serviceType);

        /// <summary>
        /// 获取指定服务类型的服务对象集合。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <returns></returns>
        IEnumerable<TService> Resolves<TService>() where TService : class;

        /// <summary>
        /// 获取指定服务类型的服务对象集合。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <returns></returns>
        IEnumerable<object> Resolves(Type serviceType);
    }
}
