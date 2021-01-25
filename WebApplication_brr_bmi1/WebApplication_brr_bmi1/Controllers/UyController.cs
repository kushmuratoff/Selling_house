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
    public class UyController : Controller
    {
        private BazaContext db = new BazaContext();
         [Authorize(Roles = "Admin")]

        // GET: /Uy/
        public ActionResult Index()
        {
            var uy = db.Uy.Include(u => u.Tuman);
            return View(uy.ToList());
        }

        // GET: /Uy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uy uy = db.Uy.Find(id);
            if (uy == null)
            {
                return HttpNotFound();
            }
            return View(uy);
        }

        // GET: /Uy/Create
        public ActionResult Create()
        {
            ViewBag.TumanId = new SelectList(db.Tuman, "Id", "Tuman_nomi");
            return View();
        }

        // POST: /Uy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Manzil,TumanId")] Uy uy)
        {
            if (ModelState.IsValid)
            {
                db.Uy.Add(uy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TumanId = new SelectList(db.Tuman, "Id", "Tuman_nomi", uy.TumanId);
            return View(uy);
        }

        // GET: /Uy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uy uy = db.Uy.Find(id);
            if (uy == null)
            {
                return HttpNotFound();
            }
            ViewBag.TumanId = new SelectList(db.Tuman, "Id", "Tuman_nomi", uy.TumanId);
            return View(uy);
        }

        // POST: /Uy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Manzil,TumanId")] Uy uy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TumanId = new SelectList(db.Tuman, "Id", "Tuman_nomi", uy.TumanId);
            return View(uy);
        }

        // GET: /Uy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uy uy = db.Uy.Find(id);
            if (uy == null)
            {
                return HttpNotFound();
            }
            return View(uy);
        }

        // POST: /Uy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uy uy = db.Uy.Find(id);
            db.Uy.Remove(uy);
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
