using System.Web.Mvc;
using NinjectDemo.Services;

namespace NinjectDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDemoService _demoService;

        public HomeController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(_demoService.GetData());
        }
    }
}