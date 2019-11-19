using Owin;
using Microsoft.Owin;
using WebApp.Demo;
using NShine.Core.Dependency;
using NShine.Web.Mvc.Initialize;
using NShine.Web.Mvc.Extensions;
using NShine.Web.WebApi.Initialize;
using NShine.Web.WebApi.Extensions;

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
