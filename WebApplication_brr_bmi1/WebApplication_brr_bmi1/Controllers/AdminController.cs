using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication_brr_bmi1.Models;
namespace WebApplication_brr_bmi1.Controllers
{
    public class AdminController : Controller
    {
        private BazaContext db = new BazaContext();

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Adminga()
        {
            ViewBag.habar = db.Xonadon.Where(x => x.Holati == 1).Count();
            return View();
        }
        public ActionResult SotilganUy()
        {
            Sahifa s = new Sahifa();
            s.Xonadon = db.Xonadon.Include(x => x.Uy).Include(x => x.Uy.Tuman).Include(x => x.Uy.Tuman.Viloyat).Where(x => x.UyId != null && x.Holati == 1).ToList();
            // var xonadon = db.Xonadon.Include(x => x.Uy);
            return View(s);
        }
        public ActionResult Tasdiqlash(int?Id)
        {
            Xonadon xon = db.Xonadon.Find(Id);
            xon.Holati = 2;
            db.SaveChanges();
            return RedirectToAction("Adminga", "Admin");
        }
	}
}