using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BugTracker_The_Reckoning.Models;
using System.IO;
using System.Web.Hosting;

namespace BugTracker_The_Reckoning.Controllers
{
    public class TicketAttachmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TicketAttachments
        public ActionResult Index()
        {
            var ticketAttachments = db.TicketAttachments.Include(t => t.Ticket);
            return View(ticketAttachments.ToList());
        }

        // GET: TicketAttachments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketAttachment ticketAttachment = db.TicketAttachments.Find(id);
            if (ticketAttachment == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubmitterName = db.Users.First(u => u.Id == ticketAttachment.UserId).DisplayName;
            return View(ticketAttachment);
        }

        // GET: TicketAttachments/Create
        public ActionResult Create(int TicketId)
        {
            TicketAttachment ticketAttachment = new TicketAttachment();
            ticketAttachment.TicketId = TicketId;
            return View(ticketAttachment);
        }

        // POST: TicketAttachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,TicketId,UserId,FilePath,Description,Created,UserId,FileUrl")] TicketAttachment ticketAttachment,
            HttpPostedFileBase fileUpload)
        {
            var file = Request.Files;
            if (ModelState.IsValid)
            {
                //restricting to valid image uploads, only
                if (fileUpload != null && fileUpload.ContentLength > 0)
                {
                    if (!fileUpload.ContentType.Contains("image"))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.UnsupportedMediaType);
                    }

                    string filename = System.IO.Path.GetFileName(fileUpload.FileName);

                    //Saving the file in server folder
                    fileUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/uploads/" + filename)));
                    ticketAttachment.FilePath = "~/Content/uploads/" + filename;

                    var path = Path.Combine(Server.MapPath("~/Content/uploads/"), filename);
                    ticketAttachment.FileUrl = HostingEnvironment.SiteName + Server.MapPath("~/Content/uploads/" + filename);

                }
                //upload url and capture name
                ticketAttachment.UserId = User.Identity.GetUserId();
                ticketAttachment.Created = DateTimeOffset.Now;
                ticketAttachment.Owner = db.Users.Find(ticketAttachment.UserId);
                db.TicketAttachments.Add(ticketAttachment);
                db.SaveChanges();
                return RedirectToAction("Details", "Tickets", new { Id = ticketAttachment.TicketId });
            }

            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Title", ticketAttachment.TicketId);
            return View(ticketAttachment);
        }

        // GET: TicketAttachments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketAttachment ticketAttachment = db.TicketAttachments.Find(id);
            if (ticketAttachment == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Title", ticketAttachment.TicketId);
            return View(ticketAttachment);
        }

        // POST: TicketAttachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TicketId,UserId,FilePath,Description,Created,FileUrl")] TicketAttachment ticketAttachment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketAttachment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Title", ticketAttachment.TicketId);
            return View(ticketAttachment);
        }

        // GET: TicketAttachments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketAttachment ticketAttachment = db.TicketAttachments.Find(id);
            if (ticketAttachment == null)
            {
                return HttpNotFound();
            }
            return View(ticketAttachment);
        }

        // POST: TicketAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketAttachment ticketAttachment = db.TicketAttachments.Find(id);
            db.TicketAttachments.Remove(ticketAttachment);
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
