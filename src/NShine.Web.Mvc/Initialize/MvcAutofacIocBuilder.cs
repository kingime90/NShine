using NShine.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NShine.Web.Mvc.Initialize
{
    /// <summary>
    /// Mvc Autofac 构建依赖注入映射。
    /// </summary>
    public class MvcAutofacIocBuilder : IocBuilderBase
    {
        /// <summary>
        /// 初始化一个<see cref="MvcAutofacIocBuilder"/>类型的新实例。
        /// </summary>
        /// <param name="services">服务映射信息集合。</param>
        public MvcAutofacIocBuilder(IServiceCollection services) : base(services)
        {

        }

        /// <summary>
        /// 添加服务类型。
        /// </summary>
        /// <param name="services">服务映射信息集合。</param>
        public override void AddServices(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 将服务映射信息注册到依赖注入容器中。
        /// </summary>
        /// <param name="services">服务映射信息集合。</param>
        /// <param name="assemblies">要检索的程序集集合。</param>
        /// <returns></returns>
        public override IServiceProvider Register(IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            throw new NotImplementedException();
        }
    }
}
