using Microsoft.Owin;
using NinjectDemo;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace NinjectDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
