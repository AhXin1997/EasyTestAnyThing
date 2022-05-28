using EasyTestAnyThing.WebServer.Attribute;
using System.Web.Http;

namespace EasyTestAnyThing.WebServer.Controller
{
    /*
     * WebApi 2 中的 FilterAttribute 介紹與應用
     * https://ronsun.github.io/content/20180923-filters-of-webapi2.html
     */
    [RoutePrefix("api/Verify")]
    public class RolesController : ApiController
    {
        [Route("IsRoles")]
        [HttpGet]
        [VerifyRoles]
        [IgnoreFilter(typeof(HandleExceptionAttribute))]
        public string VerifyRoles()
        {
            return "555";
        }
    }
}