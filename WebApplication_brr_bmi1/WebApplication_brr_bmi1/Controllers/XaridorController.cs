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
    public class XaridorController : Controller
    {
        private BazaContext db = new BazaContext();
         [Authorize(Roles = "Admin")]
        // GET: /Xaridor/
        public ActionResult Index()
        {

            var xaridor = db.Xaridor.Include(x => x.Tuman);
            return View(xaridor.ToList());

        }

        // GET: /Xaridor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xaridor xaridor = db.Xaridor.Find(id);
            if (xaridor == null)
            {
                return HttpNotFound();
            }
            return View(xaridor);
        }

        // GET: /Xaridor/Create
        public ActionResult Create()
        {
            ViewBag.TumanId = new SelectList(db.Tuman, "Id", "Tuman_nomi");
            return View();
        }

        // POST: /Xaridor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Familiya,Ismi,Sharif,tug_yili,Pas_ser,Millati,TumanId")] Xaridor xaridor)
        {
            if (ModelState.IsValid)
            {
                db.Xaridor.Add(xaridor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TumanId = new SelectList(db.Tuman, "Id", "Tuman_nomi", xaridor.TumanId);
            return View(xaridor);
        }

        // GET: /Xaridor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xaridor xaridor = db.Xaridor.Find(id);
            if (xaridor == null)
            {
                return HttpNotFound();
            }
            ViewBag.TumanId = new SelectList(db.Tuman, "Id", "Tuman_nomi", xaridor.TumanId);
            return View(xaridor);
        }

        // POST: /Xaridor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Familiya,Ismi,Sharif,tug_yili,Pas_ser,Millati,TumanId")] Xaridor xaridor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xaridor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TumanId = new SelectList(db.Tuman, "Id", "Tuman_nomi", xaridor.TumanId);
            return View(xaridor);
        }

        // GET: /Xaridor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xaridor xaridor = db.Xaridor.Find(id);
            if (xaridor == null)
            {
                return HttpNotFound();
            }
            return View(xaridor);
        }

        // POST: /Xaridor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Xaridor xaridor = db.Xaridor.Find(id);
            db.Xaridor.Remove(xaridor);
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
