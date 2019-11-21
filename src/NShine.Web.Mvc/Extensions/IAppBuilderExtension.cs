﻿using NShine.Core.Dependency;
using NShine.Core.Initialize;
using NShine.Web.Mvc.Binders;
using Owin;
using System.Web.Mvc;

namespace NShine.Web.Mvc.Extensions
{
    /// <summary>
    /// <see cref="IAppBuilder"/> 扩展方法。
    /// </summary>
    public static class IAppBuilderExtension
    {
        /// <summary>
        /// 使用 Mvc。
        /// </summary>
        /// <param name="app">应用构建器。</param>
        /// <param name="iocBuilder">构建依赖注入映射接口。</param>
        public static void UseMvc(this IAppBuilder app, IIocBuilder iocBuilder)
        {
            IFrameworkInitializer framework = new FrameworkInitializer();
            framework.Initialize(iocBuilder);
        }

        /// <summary>
        /// 配置 Mvc。
        /// </summary>
        /// <param name="app">应用构建器。</param>
        /// <returns></returns>
        public static void ConfigureMvc(this IAppBuilder app)
        {
            //模型绑定器
            ModelBinders.Binders.Add(typeof(string), new StringTrimModelBinder());
        }
    }
}
