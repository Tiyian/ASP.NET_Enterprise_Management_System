using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_EMS.Models;

namespace ASP.NET_EMS.Controllers
{
    public class GuestBookController : Controller
    {
        private GuestBookContext db = new GuestBookContext();

        // GET: GuestBook
        public ActionResult Index()
        {
            return View(db.GuestBooks.ToList());
        }

        // GET: GuestBook/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestBook guestBook = db.GuestBooks.Find(id);
            if (guestBook == null)
            {
                return HttpNotFound();
            }
            return View(guestBook);
        }

        // GET: GuestBook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestBook/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Detail")] GuestBook guestBook)
        {
            if (ModelState.IsValid)
            {
                db.GuestBooks.Add(guestBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestBook);
        }

        // GET: GuestBook/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestBook guestBook = db.GuestBooks.Find(id);
            if (guestBook == null)
            {
                return HttpNotFound();
            }
            return View(guestBook);
        }

        // POST: GuestBook/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Detail")] GuestBook guestBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guestBook);
        }

        // GET: GuestBook/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestBook guestBook = db.GuestBooks.Find(id);
            if (guestBook == null)
            {
                return HttpNotFound();
            }
            return View(guestBook);
        }

        // POST: GuestBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestBook guestBook = db.GuestBooks.Find(id);
            db.GuestBooks.Remove(guestBook);
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
