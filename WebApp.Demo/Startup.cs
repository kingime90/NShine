using Owin;
using Microsoft.Owin;
using WebApp.Demo;
using NShine.Core.Dependency;

[assembly: OwinStartup(typeof(Startup))]

namespace WebApp.Demo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IServiceBuilder builder = new ServiceBuilder();
            IServiceCollection services = builder.Build();

        }
    }
}
