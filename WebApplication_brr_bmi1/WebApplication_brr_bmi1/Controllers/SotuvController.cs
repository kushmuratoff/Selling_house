using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebApplication_brr_bmi1.Models;

namespace WebApplication_brr_bmi1.Controllers
{
    public class SotuvController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Sotuv/
        public ActionResult Index()
        {
            var sotuv = db.sotuv.Include(s => s.tulov).Include(s => s.Xaridor).Include(s => s.Xonadon);
            return View(sotuv.ToList());
        }
       
        



        // GET: /Sotuv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sotuv sotuv = db.sotuv.Find(id);
            if (sotuv == null)
            {
                return HttpNotFound();
            }
            return View(sotuv);
        }

        // GET: /Sotuv/Create
        public ActionResult Create()
        {
            ViewBag.tulovId = new SelectList(db.tulov, "Id", "Tulov_turi");
            ViewBag.XaridorId = new SelectList(db.Xaridor, "Id", "Familiya");
            ViewBag.XonadonId = new SelectList(db.Xonadon, "Id", "Narxi");
            return View();
        }

        // POST: /Sotuv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,XaridorId,XonadonId,tulovId")] sotuv sotuv)
        {
            if (ModelState.IsValid)
            {
                db.sotuv.Add(sotuv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tulovId = new SelectList(db.tulov, "Id", "Tulov_turi", sotuv.tulovId);
            ViewBag.XaridorId = new SelectList(db.Xaridor, "Id", "Familiya", sotuv.XaridorId);
            ViewBag.XonadonId = new SelectList(db.Xonadon, "Id", "Narxi", sotuv.XonadonId);
            return View(sotuv);
        }

        // GET: /Sotuv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sotuv sotuv = db.sotuv.Find(id);
            if (sotuv == null)
            {
                return HttpNotFound();
            }
            ViewBag.tulovId = new SelectList(db.tulov, "Id", "Tulov_turi", sotuv.tulovId);
            ViewBag.XaridorId = new SelectList(db.Xaridor, "Id", "Familiya", sotuv.XaridorId);
            ViewBag.XonadonId = new SelectList(db.Xonadon, "Id", "Narxi", sotuv.XonadonId);
            return View(sotuv);
        }

        // POST: /Sotuv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,XaridorId,XonadonId,tulovId")] sotuv sotuv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sotuv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tulovId = new SelectList(db.tulov, "Id", "Tulov_turi", sotuv.tulovId);
            ViewBag.XaridorId = new SelectList(db.Xaridor, "Id", "Familiya", sotuv.XaridorId);
            ViewBag.XonadonId = new SelectList(db.Xonadon, "Id", "Narxi", sotuv.XonadonId);
            return View(sotuv);
        }

        // GET: /Sotuv/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sotuv sotuv = db.sotuv.Find(id);
            if (sotuv == null)
            {
                return HttpNotFound();
            }
            return View(sotuv);
        }

        // POST: /Sotuv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sotuv sotuv = db.sotuv.Find(id);
            db.sotuv.Remove(sotuv);
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
