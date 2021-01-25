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
    public class YangilikController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Yangilik/
        public ActionResult Index()
        {
            Sahifa s = new Sahifa();
            s.Yangilik = db.Yangilik.ToList();
            return View(s);
        }
        public ActionResult More(int? Id)
        {
            Sahifa s = new Sahifa();
            s.Yangilik = db.Yangilik.Where(i=>i.Id==Id).ToList();
            return View(s);
        }

        // GET: /Yangilik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yangilik yangilik = db.Yangilik.Find(id);
            if (yangilik == null)
            {
                return HttpNotFound();
            }
            return View(yangilik);
        }

        // GET: /Yangilik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Yangilik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,Sarlovha,Rasm1,Batafsil")] Yangilik yangilik)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Yangilik.Add(yangilik);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(yangilik);
        //}

        public ActionResult Create([Bind(Include = "Id,Sarlovha,Rasm1,Batafsil")] Yangilik yangilik, HttpPostedFileBase Imagefile)
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
                    yangilik.Rasm1 = filename;
                }


                db.Yangilik.Add(yangilik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(yangilik);
        }


        // GET: /Yangilik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yangilik yangilik = db.Yangilik.Find(id);
            if (yangilik == null)
            {
                return HttpNotFound();
            }
            return View(yangilik);
        }

        // POST: /Yangilik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sarlovha,Rasm1,Batafsil")] Yangilik yangilik, HttpPostedFileBase Imagefile)
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
                    yangilik.Rasm1 = filename;
                }

                db.Entry(yangilik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(yangilik);
        }

        // GET: /Yangilik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yangilik yangilik = db.Yangilik.Find(id);
            if (yangilik == null)
            {
                return HttpNotFound();
            }
            return View(yangilik);
        }

        // POST: /Yangilik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yangilik yangilik = db.Yangilik.Find(id);
            db.Yangilik.Remove(yangilik);
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
