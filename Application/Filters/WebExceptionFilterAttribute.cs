using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Filters
{
    internal class WebExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private ILoggerManager logger;
        public WebExceptionFilterAttribute()
        {
            
        }

        public override void OnException(ExceptionContext context)
        {
            logger = context.HttpContext.RequestServices.GetService<ILoggerManager>();
            logger.SetLogger("WebExceptionLog");
            HandleException(context);
            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            logger.LogException(context.Exception);
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "Account" },
                    { "action", "LogIn" }
                });
        }
    }
}
