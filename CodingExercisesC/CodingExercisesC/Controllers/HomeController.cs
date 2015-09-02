using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingExercisesC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Jump1()
        {
            return View();
        }

        public ActionResult Jump2(string url)
        {
            var one = ViewBag.One;
            var two = ViewBag.Two;
            ViewBag.Answer = one + two;
            return Redirect(url);
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