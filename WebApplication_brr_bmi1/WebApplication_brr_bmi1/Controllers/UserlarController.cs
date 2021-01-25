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
    public class UserlarController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Userlar/
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Roles).Include(u => u.Xaridor);
            return View(users.ToList());
        }

        // GET: /Userlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: /Userlar/Create
        public ActionResult Create()
        {
            ViewBag.RolesId = new SelectList(db.Roles, "Id", "Nomi");
            ViewBag.XaridorId = new SelectList(db.Xaridor, "Id", "Familiya");
            return View();
        }

        // POST: /Userlar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Login,Password,RolesId,XaridorId")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolesId = new SelectList(db.Roles, "Id", "Nomi", users.RolesId);
            ViewBag.XaridorId = new SelectList(db.Xaridor, "Id", "Familiya", users.XaridorId);
            return View(users);
        }

        // GET: /Userlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolesId = new SelectList(db.Roles, "Id", "Nomi", users.RolesId);
            ViewBag.XaridorId = new SelectList(db.Xaridor, "Id", "Familiya", users.XaridorId);
            return View(users);
        }

        // POST: /Userlar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Login,Password,RolesId,XaridorId")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolesId = new SelectList(db.Roles, "Id", "Nomi", users.RolesId);
            ViewBag.XaridorId = new SelectList(db.Xaridor, "Id", "Familiya", users.XaridorId);
            return View(users);
        }

        // GET: /Userlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: /Userlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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
