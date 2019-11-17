using Autofac;
using Autofac.Integration.Mvc;
using NShine.Core.Dependency;
using NShine.Core.Extensions;
using System;
using System.Reflection;
using System.Web.Mvc;

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
            services.AddInstance(this);
            services.AddSingleton<IIocResolver, MvcIocResolver>();
        }

        /// <summary>
        /// 将服务映射信息注册到依赖注入容器中。
        /// </summary>
        /// <param name="services">服务映射信息集合。</param>
        /// <param name="assemblies">要检索的程序集数组。</param>
        /// <returns></returns>
        public override IServiceProvider RegisterServices(IServiceCollection services, Assembly[] assemblies)
        {
            var builder = new ContainerBuilder();
            //RegisterControllers：在提供的程序集中实现IController的注册类型。
            //AsSelf：指定来自被扫描程序集的类型将其自身的具体类型作为服务提供。
            //PropertiesAutowired：配置组件，以便将其类型在容器中注册的任何属性连接到相应服务的实例。
            builder.RegisterControllers(assemblies).AsSelf().PropertiesAutowired();
            //RegisterFilterProvider：注册过滤器提供者。
            builder.RegisterFilterProvider();
            //RegisterServices：将服务映射信息注册到依赖注入容器中。
            builder.RegisterServices(services);
            //Build：使用已经完成的组件注册创建一个新容器。
            var container = builder.Build();
            var resolver = new AutofacDependencyResolver(container);
            //SetResolver：使用指定的依赖项解析器接口为依赖项解析器提供注册点。
            DependencyResolver.SetResolver(resolver);
            //Resolve：从上下文检索服务。
            MvcIocResolver.GlobalResolveFunc = t => resolver.ApplicationContainer.Resolve(t);
            //GetService：解析支持任意对象创建的单独注册的服务。
            return resolver.GetService<IServiceProvider>();
        }
    }
}
