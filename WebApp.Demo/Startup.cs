using Microsoft.Owin;
using NShine.Core.Dependency;
using NShine.Web.Mvc.Extensions;
using NShine.Web.Mvc.Initialize;
using NShine.Web.WebApi.Extensions;
using NShine.Web.WebApi.Initialize;
using Owin;
using WebApp.Demo;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApp.Demo
{
    /// <summary>
    /// 应用程序启动。
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IServiceBuilder builder = new ServiceBuilder();
            IServiceCollection services = builder.Build();

            IIocBuilder iocBuilder = new MvcAutofacIocBuilder(services);
            app.UseMvc(iocBuilder);

            IIocBuilder apiIocBuilder = new WebApiAutofacIocBuilder(services);
            app.UseWebApi(apiIocBuilder);
            app.ConfigureWebApi();
        }
    }
}
