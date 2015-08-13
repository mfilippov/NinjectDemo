using System;
using System.Web;
using System.Web.Mvc;
using Elmah;

namespace NinjectDemo.Infrastructure.Logging
{
  public class ElmahHandledErrorLoggerFilter : IExceptionFilter
  {
    public void OnException(ExceptionContext filterContext)
    {
      if (!filterContext.ExceptionHandled) return;
      var e = filterContext.Exception;
      var httpContext = filterContext.HttpContext.ApplicationInstance.Context;
      if (httpContext != null && RaiseErrorSignal(e, httpContext)) return;
      LogException(e, httpContext);
    }

    private static bool RaiseErrorSignal(Exception e, HttpContext context)
    {
      var signal = ErrorSignal.FromContext(context);
      if (signal == null) return false;
      signal.Raise(e, context);
      return true;
    }
    private static void LogException(Exception e, HttpContext context)
    {
      ErrorLog.GetDefault(context).Log(new Error(e, context));
    }
  }
}