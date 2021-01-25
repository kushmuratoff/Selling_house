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
    public class ValyutaController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Valyuta/
        public ActionResult Index()
        {


            return View(db.Valyuta.ToList());
        }
        public ActionResult Konver()
        {
            ViewBag.valyuta = db.Valyuta.ToList();
            return View();
        }
        
        public ActionResult Hisob(double a,int b)
        {
            double sum = db.Valyuta.Where(v => v.Id == b).FirstOrDefault().Summa;
            ViewBag.nat = sum * a;
            return View();
        }

        // GET: /Valyuta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valyuta valyuta = db.Valyuta.Find(id);
            if (valyuta == null)
            {
                return HttpNotFound();
            }
            return View(valyuta);
        }

        // GET: /Valyuta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Valyuta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Summa,Nomi")] Valyuta valyuta)
        {
            if (ModelState.IsValid)
            {
                db.Valyuta.Add(valyuta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valyuta);
        }

        // GET: /Valyuta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valyuta valyuta = db.Valyuta.Find(id);
            if (valyuta == null)
            {
                return HttpNotFound();
            }
            return View(valyuta);
        }

        // POST: /Valyuta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Summa,Nomi")] Valyuta valyuta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valyuta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valyuta);
        }

        // GET: /Valyuta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valyuta valyuta = db.Valyuta.Find(id);
            if (valyuta == null)
            {
                return HttpNotFound();
            }
            return View(valyuta);
        }

        // POST: /Valyuta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valyuta valyuta = db.Valyuta.Find(id);
            db.Valyuta.Remove(valyuta);
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
