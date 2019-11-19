using NShine.Core.Dependency;
using NShine.Web.WebApi.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace NShine.Web.WebApi.Initialize
{
    /// <summary>
    /// WebApi 依赖注入解析器。
    /// </summary>
    public class WebApiIocResolver : IIocResolver
    {
        /// <summary>
        /// 获取指定服务类型的服务对象。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <returns></returns>
        public TService Resolve<TService>() where TService : class
        {
            return Resolve(typeof(TService)) as TService;
        }

        /// <summary>
        /// 获取指定服务类型的服务对象。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <returns></returns>
        public object Resolve(Type serviceType)
        {
            if (CallContext.LogicalGetData(HttpConstant.RequestLifetimeScopeKey) is IDependencyScope scope)
            {
                return scope.GetService(serviceType);
            }
            return GlobalConfiguration.Configuration.DependencyResolver.GetService(serviceType);
        }
        /// <summary>
        /// 获取指定服务类型的服务对象集合。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <returns></returns>
        public IEnumerable<TService> Resolves<TService>() where TService : class
        {
            return Resolves(typeof(TService)).Cast<TService>();
        }

        /// <summary>
        /// 获取指定服务类型的服务对象集合。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <returns></returns>
        public IEnumerable<object> Resolves(Type serviceType)
        {
            return GlobalConfiguration.Configuration.DependencyResolver.GetServices(serviceType);
        }
    }
}
