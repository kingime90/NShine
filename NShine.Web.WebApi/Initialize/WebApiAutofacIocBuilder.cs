using System;
using System.Reflection;
using NShine.Core.Dependency;
using NShine.Core.Extensions;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace NShine.Web.WebApi.Initialize
{
    /// <summary>
    /// WebApi Autofac 构建依赖注入映射。
    /// </summary>
    public class WebApiAutofacIocBuilder : IocBuilderBase
    {
        /// <summary>
        /// 初始化一个<see cref="WebApiAutofacIocBuilder"/>类型的新实例。
        /// </summary>
        /// <param name="services">服务映射信息集合。</param>
        public WebApiAutofacIocBuilder(IServiceCollection services) : base(services)
        {

        }

        /// <summary>
        /// 添加服务类型。
        /// </summary>
        /// <param name="services">服务映射信息集合。</param>
        public override void AddServices(IServiceCollection services)
        {
            services.AddInstance(this);
            services.AddSingleton<IIocResolver, WebApiIocResolver>();
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
            var config = GlobalConfiguration.Configuration;
            //RegisterApiControllers：在提供的实现System.Web.Http.Controllers.IHttpController的程序集中注册类型。和匹配默认类型名称后缀的“控制器”。
            //AsSelf：指定来自被扫描程序集的类型将其自身的具体类型作为服务提供。
            //PropertiesAutowired：配置组件，以便将其类型在容器中注册的任何属性连接到相应服务的实例。
            builder.RegisterApiControllers(assemblies).AsSelf().PropertiesAutowired();
            //RegisterWebApiFilterProvider：注册过滤器提供者。
            builder.RegisterWebApiFilterProvider(config);
            //RegisterWebApiModelBinderProvider：注册模型绑定提供者。
            builder.RegisterWebApiModelBinderProvider();
            //RegisterServices：将服务映射信息注册到依赖注入容器中。
            builder.RegisterServices(services);
            //Build：使用已经完成的组件注册创建一个新容器。
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            //DependencyResolver：获取或设置与此实例关联的依赖项解析器。
            config.DependencyResolver = resolver;
            //GetService：解析支持任意对象创建的单独注册的服务。
            return (IServiceProvider)resolver.GetService(typeof(IServiceProvider));
        }
    }
}
