using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using NinjectDemo.Services;
using Serilog;

namespace NinjectDemo
{
    public class Global : NinjectHttpApplication
    {
        IKernel _kernel;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
        }
        
        protected override IKernel CreateKernel()
        {
            _kernel = new StandardKernel();
            RegisterServices(_kernel);
            return _kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private void RegisterServices(IKernel kernel)
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IDemoService>().To<DemoService>().InRequestScope();
            kernel.Bind<ILogger>().ToConstant(new LoggerConfiguration().WriteTo.Console().CreateLogger());
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
            _kernel.Get<ILogger>().Error(Server.GetLastError(), "Unhandled error");
            Response.Redirect("/error");
        }

    }
}