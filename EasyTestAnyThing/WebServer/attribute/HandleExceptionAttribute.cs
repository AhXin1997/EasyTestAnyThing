using EasyTestAnyThing.WebServer.attribute.Model;
using System;
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
            Func<IgnoreFilterAttribute, bool> ignoreCheck = (r) =>
            {
                return r.FilterType.IsAssignableFrom(typeof(HandleExceptionAttribute));
            };

            var ignoredActions = actionExecutedContext
                                    .ActionContext
                                    .ActionDescriptor
                                    .GetCustomAttributes<IgnoreFilterAttribute>()
                                    .Any(ignoreCheck);

            var ignoredControllers = actionExecutedContext
                                        .ActionContext
                                        .ControllerContext
                                        .ControllerDescriptor
                                        .GetCustomAttributes<IgnoreFilterAttribute>()
                                        .Any(ignoreCheck);

            if (ignoredActions || ignoredControllers)
            {
                actionExecutedContext.Response = 
                    actionExecutedContext
                    .Request
                    .CreateResponse(
                        HttpStatusCode.OK, 
                        new ErrorResult() 
                        {
                            Message = "忽略路線",
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
                            Message = "沒忽略路線",
                            ErrorCode = (int)HttpStatusCode.InternalServerError
                        });
        }

    }

    internal class Tes
    {
        public Tes()
        {
        }
    }
}