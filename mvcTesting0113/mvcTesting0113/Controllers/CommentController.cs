using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcTesting0113.Models;

namespace mvcTesting0113.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comment
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Author).Include(c => c.ParentPost);
            return View(comments.ToList());
        }

        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comment/Create
        public ActionResult Create(int id)
        {
            //FIX LATER HUGH
            //ViewBag.Authorid = new SelectList(db.ApplicationUsers, "Id", "FirstName");
            var model = new Comment { PostId = id };
            return View(model);
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Body,UpdateReason")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Created = System.DateTimeOffset.UtcNow;
                comment.Updated = null;
                //comment.Authorid = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
                comment.UpdateReason = null;
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index", "Posts");
            }

            //FIX LATER HUGH
            //ViewBag.Authorid = new SelectList(db.ApplicationUsers, "Id", "FirstName", comment.Authorid);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            
            //FIX LATER HUGH
            //ViewBag.Authorid = new SelectList(db.ApplicationUsers, "Id", "FirstName", comment.Authorid);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostId,Authorid,Body,Created,Updated,UpdateReason")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            //FIX LATER HUGH
            //ViewBag.Authorid = new SelectList(db.ApplicationUsers, "Id", "FirstName", comment.Authorid);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
