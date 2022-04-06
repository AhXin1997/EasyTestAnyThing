using EasyTestAnyThing.WebServer.attribute.Model;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace EasyTestAnyThing.WebServer.attribute
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            bool IgnoreCheck(IgnoreFilterAttribute r)
            {
                return r.FilterType.IsAssignableFrom(typeof(HandleExceptionAttribute));
            }

            var ignoredActions = actionExecutedContext
                                    .ActionContext
                                    .ActionDescriptor
                                    .GetCustomAttributes<IgnoreFilterAttribute>()
                                    .Any(IgnoreCheck);

            var ignoredControllers = actionExecutedContext
                                        .ActionContext
                                        .ControllerContext
                                        .ControllerDescriptor
                                        .GetCustomAttributes<IgnoreFilterAttribute>()
                                        .Any(IgnoreCheck);

            if (ignoredActions || ignoredControllers)
            {
                actionExecutedContext.Response =
                    actionExecutedContext
                    .Request
                    .CreateResponse(
                        HttpStatusCode.OK,
                        new ErrorResult()
                        {
                            Message = actionExecutedContext.Exception.Message + "- 忽略路線",
                            ErrorCode = (int)HttpStatusCode.OK
                        });
                return;
            }

            actionExecutedContext.Response =
                    actionExecutedContext
                    .Request
                    .CreateResponse(
                        HttpStatusCode.InternalServerError,
                        new ErrorResult()
                        {
                            Message = actionExecutedContext.Exception.Message + "- 沒忽略路線",
                            ErrorCode = (int)HttpStatusCode.InternalServerError
                        });
        }
    }
}