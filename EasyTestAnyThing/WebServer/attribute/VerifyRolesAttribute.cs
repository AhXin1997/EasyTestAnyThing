using EasyTestAnyThing.WebServer.DataSpace;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EasyTestAnyThing.WebServer.attribute
{
    public class VerifyRolesAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var getRole = actionContext.Request.Headers
                .FirstOrDefault(f => f.Key == "Role");

            if (getRole.Value == null ||
                !(getRole.Value.Where(w => MyData.Roles.Contains(w)).Any()))
            {
                throw new System.Exception("無權限進入");
            }
        }
    }
}