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
    public class ViloyatController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Viloyat/
        public ActionResult Index()
        {
            return View(db.Viloyat.ToList());
        }

        // GET: /Viloyat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viloyat viloyat = db.Viloyat.Find(id);
            if (viloyat == null)
            {
                return HttpNotFound();
            }
            return View(viloyat);
        }

        // GET: /Viloyat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Viloyat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Viloyat_nomi")] Viloyat viloyat)
        {
            if (ModelState.IsValid)
            {
                db.Viloyat.Add(viloyat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viloyat);
        }

        // GET: /Viloyat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viloyat viloyat = db.Viloyat.Find(id);
            if (viloyat == null)
            {
                return HttpNotFound();
            }
            return View(viloyat);
        }

        // POST: /Viloyat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Viloyat_nomi")] Viloyat viloyat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viloyat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viloyat);
        }

        // GET: /Viloyat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viloyat viloyat = db.Viloyat.Find(id);
            if (viloyat == null)
            {
                return HttpNotFound();
            }
            return View(viloyat);
        }

        // POST: /Viloyat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viloyat viloyat = db.Viloyat.Find(id);
            db.Viloyat.Remove(viloyat);
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
