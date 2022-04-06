using EasyTestAnyThing.WebServer.attribute;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(EasyTestAnyThing.WebServer.Startup))]

namespace EasyTestAnyThing.WebServer
{
    public static class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            // 如需如何設定應用程式的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkID=316888

            var config = new HttpConfiguration();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            

            config.MapHttpAttributeRoutes();

            //全域設置
            config.Filters.Add(new HandleExceptionAttribute());

            app.UseWebApi(config);
        }
    }
}