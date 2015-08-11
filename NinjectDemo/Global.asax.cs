using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Elmah;
using Ninject;
using Ninject.Web.Common;
using NinjectDemo.Infrastructure.Logging;
using NinjectDemo.Services;

namespace NinjectDemo
{
    public class Global : NinjectHttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandledErrorLoggerFilter());
            filters.Add(new IpAccessListAttribute());
        }
        
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private void RegisterServices(IKernel kernel)
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IDemoService>().To<DemoService>().InRequestScope();
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RouteTable.Routes.MapMvcAttributeRoutes();
        }

        protected void Application_Error(object sender, EventArgs args)
        {
            ErrorLog.GetDefault(HttpContext.Current).Log(new Error(Server.GetLastError(), HttpContext.Current));
        }

    }
}