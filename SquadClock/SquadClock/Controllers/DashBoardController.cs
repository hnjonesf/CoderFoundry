using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SquadClock.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class DashBoardController : Controller
    {
        // GET: DashBoard/Details/5
        public ActionResult DashBoard(int id)
        {
            //limit to employee company, only from identity in ApplicationUser
            return View();
        }
    }
}
