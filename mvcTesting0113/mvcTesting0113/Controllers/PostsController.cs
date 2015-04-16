using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using mvcTesting0113.Models;
using System.IO;

namespace mvcTesting0113.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        [HttpPost]
        public ActionResult Index(string searchStr)
        {
        // query finds all posts where the search string is found in the post title or body,
        // or in any of the comments, including infor related to the comment, the author
        // body, or the reason the comment was updated.
        var result = db.Posts.Where (p => p.Body.Contains (searchStr))
            .Union(db.Posts.Where (p => p.Title.Contains(searchStr)))
            .Union(db.Posts.Where (p => p.Comments.Any(c => c.Body.Contains(searchStr))))
            .Union(db.Posts.Where (p => p.Comments.Any(c => c.Author.DisplayName.Contains(searchStr))))
            .Union(db.Posts.Where (p => p.Comments.Any(c => c.Author.FirstName.Contains(searchStr))))
            .Union(db.Posts.Where (p => p.Comments.Any(c => c.Author.LastName.Contains(searchStr))))
            .Union(db.Posts.Where (p => p.Comments.Any(c => c.Author.UserName.Contains(searchStr))))
            .Union(db.Posts.Where (p => p.Comments.Any(c => c.Author.Email.Contains(searchStr))))
            .Union(db.Posts.Where (p => p.Comments.Any(c => c.UpdateReason.Contains(searchStr))));

            return View(result.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Body,MediaURL")] Post post,
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
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    fileUpload.SaveAs(Path.Combine(Server.MapPath("~/img/blog/"), fileName));
                    post.MediaURL = "~/img/blog/" + fileName;
                }

                post.Created = new DateTimeOffset(DateTime.Now);
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // POST: /AddComment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment([Bind(Include = "PostId,Body,UpdateReason")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Created = System.DateTimeOffset.UtcNow;
                comment.Updated = null;
                comment.Authorid = User.Identity.GetUserId();
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index", "Posts");
            }

            ////FIX LATER HUGH
            ////ViewBag.Authorid = new SelectList(db.ApplicationUsers, "Id", "FirstName", comment.Authorid);
            //ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }





        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Created,Updated,Title,Body,MediaURL")] Post post)
            //ok, do I pull the fields from the following Bind to keep them from the view?
        public ActionResult Edit([Bind(Include = "Id,Title,Body,MediaURL")] Post post)
        {
            if (ModelState.IsValid)
            {
                var realPost = db.Posts.Find(post.Id);
                realPost.Title = post.Title;
                realPost.Body = post.Body;
                realPost.Updated = DateTime.Now;
                realPost.MediaURL = post.MediaURL;
                db.Entry(realPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
