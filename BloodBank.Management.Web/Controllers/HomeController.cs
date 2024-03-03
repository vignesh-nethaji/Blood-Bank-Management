using System.Web.Mvc;

namespace BloodBank.Management.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            ViewBag.ControllerName = "Home";
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}