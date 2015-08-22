using SquadClock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SquadClock.Controllers
{
    public class DetailPunchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DetailPunch/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = db.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
    }
}
