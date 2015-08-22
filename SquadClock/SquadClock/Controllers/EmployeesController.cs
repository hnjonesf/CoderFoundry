using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SquadClock.Models;

namespace SquadClock.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Company).Include(e => e.Department).Include(e => e.Job).Include(e => e.Manager);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "ApplicationUserId");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobName");
            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "ManagerTitle");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,DepartmentId,ManagerId,JobId,FirstName,LastName,EmployeeEmail,Active,EmployeePassword,EmployeeTimezone,AllowChangePassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "ApplicationUserId", employee.CompanyId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobName", employee.JobId);
            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "ManagerTitle", employee.ManagerId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "ApplicationUserId", employee.CompanyId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobName", employee.JobId);
            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "ManagerTitle", employee.ManagerId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,DepartmentId,ManagerId,JobId,FirstName,LastName,EmployeeEmail,Active,EmployeePassword,EmployeeTimezone,AllowChangePassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "ApplicationUserId", employee.CompanyId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", employee.DepartmentId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobName", employee.JobId);
            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "ManagerTitle", employee.ManagerId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        // GET: Punch In Unregistered User based on Employee Code/Verification
        public ActionResult Punch()
        {
            return View();
        }

        [AllowAnonymous]
        // GET: Employees/Punch Post Employee Code/Verification punch in/out
        [HttpPost]
        public ActionResult Punch(Employee model)
        {
            Employee employee = db.Employees.FirstOrDefault(e => e.Email == model.Email);

            if ((employee == null) || employee.Email != model.Email)
            {
                return HttpNotFound();
            }
            return RedirectToAction("DetailPunch", "Employees");
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
