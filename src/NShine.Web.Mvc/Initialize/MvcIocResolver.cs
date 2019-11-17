using NShine.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NShine.Web.Mvc.Initialize
{
    /// <summary>
    /// Mvc 依赖注入解析器。
    /// </summary>
    public class MvcIocResolver : IIocResolver
    {
        /// <summary>
        /// 初始化一个<see cref="MvcIocResolver"/>类型的新实例。
        /// </summary>
        public MvcIocResolver()
        {

        }

        /// <summary>
        /// 从全局容器中解析对象委托。
        /// </summary>
        public static Func<Type, object> GlobalResolveFunc { private get; set; }

        /// <summary>
        /// 获取指定服务类型的服务对象。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <returns></returns>
        public TService Resolve<TService>() where TService : class
        {
            try
            {
                return DependencyResolver.Current.GetService<TService>();
            }
            catch
            {
                if (GlobalResolveFunc != null)
                {
                    return (TService)GlobalResolveFunc(typeof(TService));
                }
            }
            return default(TService);
        }

        /// <summary>
        /// 获取指定服务类型的服务对象。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <returns></returns>
        public object Resolve(Type serviceType)
        {
            try
            {
                return DependencyResolver.Current.GetService(serviceType);
            }
            catch
            {
                if (GlobalResolveFunc != null)
                {
                    return GlobalResolveFunc(serviceType);
                }
            }
            return null;
        }

        /// <summary>
        /// 获取指定服务类型的服务对象集合。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <returns></returns>
        public IEnumerable<TService> Resolves<TService>() where TService : class
        {
            return DependencyResolver.Current.GetServices<TService>();
        }

        /// <summary>
        /// 获取指定服务类型的服务对象集合。
        /// </summary>
        /// <param name="serviceType">服务类型。</param>
        /// <returns></returns>
        public IEnumerable<object> Resolves(Type serviceType)
        {
            return DependencyResolver.Current.GetServices(serviceType);
        }
    }
}
