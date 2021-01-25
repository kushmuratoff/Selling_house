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
    public class TulovController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Tulov/
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var name = db.Users.Where(u => u.Login == User.Identity.Name).FirstOrDefault().RolesId;
                var name1 = db.Roles.Where(a => a.Id == name).FirstOrDefault().Nomi;
                if (name1 == "Admin")
                {
                    ViewBag.ha = "Admin";
                    return RedirectToAction("IndexFoy");
                }
                else
                {
                    ViewBag.ha = "Foy";
                }
            }
            else
            {
                ViewBag.ha = "Meh";
            }

            return View(db.tulov.ToList());
        }
        public  ActionResult IndexFoy()
        {

            return View(db.tulov.ToList());
        }


        // GET: /Tulov/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tulov tulov = db.tulov.Find(id);
            if (tulov == null)
            {
                return HttpNotFound();
            }
            return View(tulov);
        }

        // GET: /Tulov/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Tulov/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Tulov_turi")] tulov tulov)
        {
            if (ModelState.IsValid)
            {
                db.tulov.Add(tulov);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tulov);
        }

        // GET: /Tulov/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tulov tulov = db.tulov.Find(id);
            if (tulov == null)
            {
                return HttpNotFound();
            }
            return View(tulov);
        }

        // POST: /Tulov/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Tulov_turi")] tulov tulov)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tulov).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tulov);
        }

        // GET: /Tulov/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tulov tulov = db.tulov.Find(id);
            if (tulov == null)
            {
                return HttpNotFound();
            }
            return View(tulov);
        }

        // POST: /Tulov/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tulov tulov = db.tulov.Find(id);
            db.tulov.Remove(tulov);
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
