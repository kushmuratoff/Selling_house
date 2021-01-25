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
    public class TumanController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Tuman/
        public ActionResult Index()
        {
            var tuman = db.Tuman.Include(t => t.Viloyat);
            return View(tuman.ToList());
        }

        // GET: /Tuman/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuman tuman = db.Tuman.Find(id);
            if (tuman == null)
            {
                return HttpNotFound();
            }
            return View(tuman);
        }

        // GET: /Tuman/Create
        public ActionResult Create()
        {
            ViewBag.ViloyatId = new SelectList(db.Viloyat, "Id", "Viloyat_nomi");
            return View();
        }

        // POST: /Tuman/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Tuman_nomi,ViloyatId")] Tuman tuman)
        {
            if (ModelState.IsValid)
            {
                db.Tuman.Add(tuman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ViloyatId = new SelectList(db.Viloyat, "Id", "Viloyat_nomi", tuman.ViloyatId);
            return View(tuman);
        }

        // GET: /Tuman/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuman tuman = db.Tuman.Find(id);
            if (tuman == null)
            {
                return HttpNotFound();
            }
            ViewBag.ViloyatId = new SelectList(db.Viloyat, "Id", "Viloyat_nomi", tuman.ViloyatId);
            return View(tuman);
        }

        // POST: /Tuman/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Tuman_nomi,ViloyatId")] Tuman tuman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ViloyatId = new SelectList(db.Viloyat, "Id", "Viloyat_nomi", tuman.ViloyatId);
            return View(tuman);
        }

        // GET: /Tuman/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuman tuman = db.Tuman.Find(id);
            if (tuman == null)
            {
                return HttpNotFound();
            }
            return View(tuman);
        }

        // POST: /Tuman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tuman tuman = db.Tuman.Find(id);
            db.Tuman.Remove(tuman);
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
