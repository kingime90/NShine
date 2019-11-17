using NShine.Core.Dependency;
using System;
using System.Collections.Generic;

namespace NShine.Web.WebApi.Initialize
{
    public class WebApiIocResolver : IIocResolver
    {
        /// <summary>
        /// 获取指定服务类型的服务对象。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <returns></returns>
        public TService Resolve<TService>() where TService : class
        {

        }

        /// <summary>
        /// 获取指定服务类型的服务对象。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <returns></returns>
        public object Resolve(Type serviceType)
        {

        }
        /// <summary>
        /// 获取指定服务类型的服务对象集合。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <returns></returns>
        public IEnumerable<TService> Resolves<TService>() where TService : class
        {

        }

        /// <summary>
        /// 获取指定服务类型的服务对象集合。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <returns></returns>
        public IEnumerable<object> Resolves(Type serviceType)
        {

        }
    }
}
