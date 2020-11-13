using System.Web.Mvc;

namespace SAT.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize (Roles ="Admin,Scheduler")]
        [HttpGet]
        public ActionResult AdminMenu()
        {
            ViewBag.Message = "Admin Menu";

            return View();
        }
    }
}
