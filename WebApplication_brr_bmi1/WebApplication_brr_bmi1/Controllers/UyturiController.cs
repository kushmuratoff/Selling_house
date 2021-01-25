using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_brr_bmi1.Models;

namespace WebApplication_brr_bmi1.Controllers
{
    public class UyturiController : Controller
    {
        private BazaContext db = new BazaContext();
         [Authorize(Roles = "Admin")]

        // GET: /Uyturi/
        public ActionResult Index()
        {
            return View(db.Uyturi.ToList());
        }

        // GET: /Uyturi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uyturi uyturi = db.Uyturi.Find(id);
            if (uyturi == null)
            {
                return HttpNotFound();
            }
            return View(uyturi);
        }

        // GET: /Uyturi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Uyturi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nomi")] Uyturi uyturi)
        {
            if (ModelState.IsValid)
            {
                db.Uyturi.Add(uyturi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uyturi);
        }

        // GET: /Uyturi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uyturi uyturi = db.Uyturi.Find(id);
            if (uyturi == null)
            {
                return HttpNotFound();
            }
            return View(uyturi);
        }

        // POST: /Uyturi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nomi")] Uyturi uyturi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uyturi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uyturi);
        }

        // GET: /Uyturi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uyturi uyturi = db.Uyturi.Find(id);
            if (uyturi == null)
            {
                return HttpNotFound();
            }
            return View(uyturi);
        }

        // POST: /Uyturi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uyturi uyturi = db.Uyturi.Find(id);
            db.Uyturi.Remove(uyturi);
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
