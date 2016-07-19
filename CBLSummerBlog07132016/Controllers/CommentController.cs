using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CBLSummerBlog07132016.Models;

namespace CBLSummerBlog07132016.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comment
        public ActionResult Index()
        {
            return View(db.CommentViewModels.ToList());
        }

        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment commentViewModel = db.CommentViewModels.Find(id);
            if (commentViewModel == null)
            {
                return HttpNotFound();
            }
            return View(commentViewModel);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PostId,AuthorId,CommentBodyText,CommentCreateDate,CommentUpdateDate,UpdateReason")] Comment commentViewModel)
        {
            if (ModelState.IsValid)
            {
                db.CommentViewModels.Add(commentViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commentViewModel);
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment commentViewModel = db.CommentViewModels.Find(id);
            if (commentViewModel == null)
            {
                return HttpNotFound();
            }
            return View(commentViewModel);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostId,AuthorId,CommentBodyText,CommentCreateDate,CommentUpdateDate,UpdateReason")] Comment commentViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commentViewModel);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment commentViewModel = db.CommentViewModels.Find(id);
            if (commentViewModel == null)
            {
                return HttpNotFound();
            }
            return View(commentViewModel);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment commentViewModel = db.CommentViewModels.Find(id);
            db.CommentViewModels.Remove(commentViewModel);
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
