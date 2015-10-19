using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using AccountsAtAGlance.Models;

namespace AccountsAtAGlance.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cars
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MakeSortParm = String.IsNullOrEmpty(sortOrder) ? "make_desc" : "";
            ViewBag.YearSortParm = sortOrder == "Year" ? "year_desc" : "Year";
            ViewBag.ModelSortParm = sortOrder == "Model" ? "model_desc" : "Model";
            ViewBag.TrimSortParm = sortOrder == "Trim" ? "trim_desc" : "Trim";
            ViewBag.CostSortParm = sortOrder == "Cost" ? "cost_desc" : "Cost";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var cars = from s in db.Cars
                       select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Make.Contains(searchString)
                                       || s.Model.Contains(searchString)
                                       || s.Trim.Contains(searchString)
                                       || s.Year.ToString().Contains(searchString)
                                       );
            }
            switch (sortOrder)
            {
                case "make_desc":
                    cars = cars.OrderByDescending(s => s.Make);
                    break;
                case "Year":
                    cars = cars.OrderBy(s => s.Year);
                    break;
                case "year_desc":
                    cars = cars.OrderByDescending(s => s.Year);
                    break;
                case "Model":
                    cars = cars.OrderBy(s => s.Model);
                    break;
                case "model_desc":
                    cars = cars.OrderByDescending(s => s.Model);
                    break;
                case "Trim":
                    cars = cars.OrderBy(s => s.Trim);
                    break;
                case "trim_desc":
                    cars = cars.OrderByDescending(s => s.Trim);
                    break;
                case "Cost":
                    cars = cars.OrderBy(s => s.Cost);
                    break;
                case "cost_desc":
                    cars = cars.OrderByDescending(s => s.Cost);
                    break;
                default:
                    cars = cars.OrderBy(s => s.Make);
                    break;
            }

            double pageCost = 0;
            foreach (var car in cars)
            {
                pageCost += car.Cost;
            }
            ViewBag.PageCost = pageCost;


            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(cars.ToPagedList(pageNumber, pageSize));
            //return View(cars.ToList());

        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Make,Year,Model,Trim,Cost")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Make,Year,Model,Trim,Cost")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
