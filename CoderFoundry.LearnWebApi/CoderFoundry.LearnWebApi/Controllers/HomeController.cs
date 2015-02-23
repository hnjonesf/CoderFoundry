using System.Web.Mvc;

namespace CoderFoundry.LearnWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Northwind()
        {
            return View();
        }
    }
}
