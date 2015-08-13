using System.Web.Mvc;
using NinjectDemo.Infrastructure.Logging;

namespace NinjectDemo.Controllers
{
    [IpAccessList(IpList = new[] { "127.0.0.1", "::1" })]
    [RoutePrefix("admin/log")]
    public class LogController : Controller
    {
        [Route("")]
        
        public ActionResult Index()
        {
            return new ElmahResult(true);
        }

        [Route("about")]
        [Route("detail")]
        [Route("digestrss")]
        [Route("download")]
        [Route("rss")]
        [Route("stylesheet")]
        public ActionResult NotIndex()
        {
            return new ElmahResult(false);
        }


    }
}