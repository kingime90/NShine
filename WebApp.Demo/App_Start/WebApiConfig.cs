using NShine.Web.WebApi.Binders;
using System.Web.Http;

namespace WebApp.Demo.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //模型绑定器
            config.BindParameter(typeof(string), new StringTrimModelBinder());
            //config.BindParameter(typeof(UserLoginModel), new UserLoginModelBinder());

            //config.Services.Insert(typeof(ModelBinderProvider), 0, new SimpleModelBinderProvider(typeof(UserLoginModel), new UserLoginModelBinder()));

            // 启用 WebApi 特性路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}