using FirstChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstChallenge.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var comics = ComicBookManager.GetComicBooks();
            return View(comics);
        }

        // Get: Details/5
        public ActionResult Detail(int id) 
        {
            var comics = ComicBookManager.GetComicBooks();
            var comic = comics.FirstOrDefault(c => c.ComicBookId == id);

            return View(comic);
        
        }
    }
}