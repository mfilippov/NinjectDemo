using System.Web.Mvc;
using Elmah;

namespace NinjectDemo.Infrastructure.Logging
{
    public class ElmahResult : ActionResult
    {
        private readonly bool _isIndex;

        public ElmahResult(bool isIndex)
        {
            _isIndex = isIndex;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context?.HttpContext?.Request.Path == null || context.HttpContext.ApplicationInstance == null)
            {
                return;
            }
            if (_isIndex)
            {
                if (context.HttpContext.Request.Path.EndsWith("/"))
                {
                    var newPath = context.HttpContext.Request.Path.Remove(context.HttpContext.Request.Path.Length - 1);
                    context.HttpContext.RewritePath(newPath, null, context.HttpContext.Request.QueryString.ToString());
                }
            }
            else
            {
                var parts = context.HttpContext.Request.Path.Split('/');
                var pathInfo = $".{parts[parts.Length - 1]}";
                var newPath = context.HttpContext.Request.Path.Remove(context.HttpContext.Request.Path.Length - pathInfo.Length);
                context.HttpContext.RewritePath(newPath, pathInfo, context.HttpContext.Request.QueryString.ToString());
            }
            var unwrappedHttpContext = context.HttpContext.ApplicationInstance.Context;
            var handler = new ErrorLogPageFactory().GetHandler(unwrappedHttpContext, null, null, null);
            handler?.ProcessRequest(unwrappedHttpContext);
        }
    }
}