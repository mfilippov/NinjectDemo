using System.Web.Mvc;

namespace NinjectDemo.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [Route("")]
        // GET: Home
        public ActionResult Index()
        {
            return Content(@"<a href=""/bug"">Click me for crash!</a>");
        }

        [Route("bug")]
        public ActionResult BugPage(int id)
        {
            return Content("This is page with bug");
        }
    }
}