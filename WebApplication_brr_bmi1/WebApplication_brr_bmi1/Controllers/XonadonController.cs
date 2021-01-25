using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_brr_bmi1.Models;
using System.IO;

namespace WebApplication_brr_bmi1.Controllers
{
    public class XonadonController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Xonadon/


        public ActionResult Index()
        {

            var xonadon = db.Xonadon.Include(x => x.Uy);
            return View(xonadon.ToList());
        }
       
        public ActionResult Korish(int? Id)
        {
            var user = db.Users.Where(u => u.XaridorId == Id).ToList();
            return View(user.ToList());
        }

        // GET: /Xonadon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xonadon xonadon = db.Xonadon.Find(id);
            if (xonadon == null)
            {
                return HttpNotFound();
            }
            return View(xonadon);
        }

        // GET: /Xonadon/Create
        public ActionResult Create()
        {
            ViewBag.UyId = new SelectList(db.Uy, "Id", "Manzil");
            return View();
        }

        // POST: /Xonadon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind(Include = "Id,Xonalar_soni,Nechnchi_qavat,Narxi,Malumot,UyId")] Xonadon xonadon, HttpPostedFileBase Imagefile)
        {
            if (ModelState.IsValid)
            {
                if (Imagefile != null)
                {
                    string path = Server.MapPath("~/Image/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filename = Path.GetFileName(Imagefile.FileName);
                    Imagefile.SaveAs(path + Path.GetFileName(Imagefile.FileName));
                    xonadon.Malumot = filename;
                }
                

                db.Xonadon.Add(xonadon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UyId = new SelectList(db.Uy, "Id", "Manzil", xonadon.UyId);
            return View(xonadon);
        }

        // GET: /Xonadon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xonadon xonadon = db.Xonadon.Find(id);
            if (xonadon == null)
            {
                return HttpNotFound();
            }

            ViewBag.UyId = new SelectList(db.Uy, "Id", "Manzil", xonadon.UyId);
            return View(xonadon);
        }

        // POST: /Xonadon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Xonalar_soni,Nechnchi_qavat,Narxi,Malumot,UyId")] Xonadon xonadon, HttpPostedFileBase Imagefile)
        {
            if (ModelState.IsValid)
            {
                if (Imagefile != null)
                {
                    string path = Server.MapPath("~/Image/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filename = Path.GetFileName(Imagefile.FileName);
                    Imagefile.SaveAs(path + Path.GetFileName(Imagefile.FileName));
                    xonadon.Malumot = filename;
                }

                db.Entry(xonadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UyId = new SelectList(db.Uy, "Id", "Manzil", xonadon.UyId);
            return View(xonadon);
        }

        // GET: /Xonadon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xonadon xonadon = db.Xonadon.Find(id);
            if (xonadon == null)
            {
                return HttpNotFound();
            }
            return View(xonadon);
        }

        // POST: /Xonadon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Xonadon xonadon = db.Xonadon.Find(id);
            db.Xonadon.Remove(xonadon);
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
