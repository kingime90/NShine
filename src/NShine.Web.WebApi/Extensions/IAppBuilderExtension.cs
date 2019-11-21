using NShine.Core.Dependency;
using NShine.Core.Initialize;
using NShine.Web.WebApi.Binders;
using NShine.Web.WebApi.Handlers;
using NShine.Web.WebApi.Utils;
using Owin;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;

namespace NShine.Web.WebApi.Extensions
{
    /// <summary>
    /// <see cref="IAppBuilder"/> 扩展方法。
    /// </summary>
    public static class IAppBuilderExtension
    {
        /// <summary>
        /// 使用 WebApi。
        /// </summary>
        /// <param name="app">应用构建器。</param>
        /// <param name="iocBuilder">构建依赖注入映射接口。</param>
        public static void UseWebApi(this IAppBuilder app, IIocBuilder iocBuilder)
        {
            IFrameworkInitializer framework = new FrameworkInitializer();
            framework.Initialize(iocBuilder);
        }

        /// <summary>
        /// 配置 WebApi。
        /// </summary>
        /// <param name="app">应用构建器。</param>
        /// <returns></returns>
        public static void ConfigureWebApi(this IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;

            //注册消息处理器
            config.MessageHandlers.Add(new RequestLifetimeScopeHandler());

            //注册关联的默认服务的容器

            //注册媒体类型格式化程序
            config.Formatters.Clear();
            config.Formatters.Add(JsonFormatterUtil.BuildSettings(new JsonMediaTypeFormatter()));
        }
    }
}
