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
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog
        public ActionResult Index()
        {
            return View(db.BlogPosts.ToList());
        }

        public ActionResult IndexCopy()
        {
            return View(db.BlogPosts.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost BlogPost = db.BlogPosts.Find(id);
            if (BlogPost == null)
            {
                return HttpNotFound();
            }
            return View(BlogPost);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreateDate,UpdateDate,Title,BodyText,MediaUrl")] BlogPost BlogPost)
        {
            if (ModelState.IsValid)
            {
                db.BlogPosts.Add(BlogPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(BlogPost);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost BlogPost = db.BlogPosts.Find(id);
            if (BlogPost == null)
            {
                return HttpNotFound();
            }
            return View(BlogPost);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateDate,UpdateDate,Title,BodyText,MediaUrl")] BlogPost BlogPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(BlogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(BlogPost);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost BlogPost = db.BlogPosts.Find(id);
            if (BlogPost == null)
            {
                return HttpNotFound();
            }
            return View(BlogPost);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost BlogPost = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(BlogPost);
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
