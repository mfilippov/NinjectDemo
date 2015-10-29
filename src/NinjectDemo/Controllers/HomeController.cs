using System.Web.Mvc;
using Serilog;
using NinjectDemo.Services;
using System;

namespace NinjectDemo.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        ILogger _logger;

        IDemoService _demoService;

        public HomeController (ILogger logger, IDemoService demoService)
        {
            _demoService = demoService;
            _logger = logger;
            
        }
        [Route("")]
        public ActionResult Index()
        {
            _logger.Information("Get index");
            return View(_demoService.GetData());
        }

        [Route("bug")]
        public ActionResult BugPage(int id)
        {
            return Content("Shit happend!");
        }

        [Route("error")]
        public ActionResult Error() 
        {
            return View();
        }
    }
}