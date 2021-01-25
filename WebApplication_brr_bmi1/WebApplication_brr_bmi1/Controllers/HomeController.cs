using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_brr_bmi1.Models;
using System.Data.Entity;
using System.Web.Security;
namespace WebApplication_brr_bmi1.Controllers
{
    public class HomeController : Controller
    {
        public BazaContext db = new BazaContext();
        
        public ActionResult Index()
        {
            Sahifa s = new Sahifa();
            s.Xonadon = db.Xonadon.Include(x => x.Uy).Include(x => x.Uy.Tuman).Include(x => x.Uy.Tuman.Viloyat).Where(x => x.UyId != null).ToList();
            // var xonadon = db.Xonadon.Include(x => x.Uy);
            return View(s);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Register()
        {
            ViewBag.habar = "";
            return View();
        }
        [HttpPost]
        public ActionResult Register(string Login,string Parol)
        {
           
            WebApplication_brr_bmi1.Models.Users user= null;
            user = db.Users.Where(u => u.Login == Login).FirstOrDefault();
            if(user!=null)
            {
                ViewBag.habar = "Bunday foydalanuvchi mavjud";
                return View();
            }
            else
            {
                return RedirectToAction("Saqlash","Home",new {Login=Login,Parol=Parol});
            }
            
        }
        public ActionResult Saqlash(string Login, string Parol)
        {
            ViewBag.Tum = db.Tuman.ToList();
            ViewBag.Login = Login;
            ViewBag.Parol = Parol;
            return View();
        }
        [HttpPost]
        public ActionResult Saqlash(string Login, string Parol, string Fam, string Ism, string Shar, int? TumId, string PasM, string Millati, DateTime tugyil)
        {
            Xaridor xaridor = new Xaridor();
            xaridor.Familiya = Fam;
            xaridor.Ismi = Ism;
            xaridor.Sharif = Shar;
            xaridor.tug_yili = tugyil;
            xaridor.Millati = Millati;
            xaridor.TumanId = TumId;
            xaridor.Pas_ser = PasM;
            db.Xaridor.Add(xaridor);
            db.SaveChanges();
            var idsi = db.Xaridor.Where(x=>x.Familiya==Fam && x.Pas_ser==PasM).FirstOrDefault().Id;
            Users user = new Users();
            user.Login = Login;
            user.Password = Parol;
            user.XaridorId = db.Xaridor.Where(x => x.Id == idsi).FirstOrDefault().Id;
            user.RolesId = 2;
            db.Users.Add(user);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Krish()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Krish( string Login ,string Parol)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Users user = null;
                using (BazaContext db = new BazaContext())
                {
                    user = db.Users.Where(u => u.Login == Login &&
                    u.Password == Parol).FirstOrDefault();
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(Login, true);
                    var rolee = user.RolesId;
                    BazaContext db = new BazaContext();
                    var nomi = db.Roles.Where(r => r.Id == rolee).First().Nomi;
                    var useridd = user.Id;

                    switch (nomi)
                    {
                        case "Admin": { return RedirectToAction("Adminga", "Admin"); } break;
                        case "Bemor": { return RedirectToAction("Index", "Bemor"); } break;
                        case "Administrator": { return RedirectToAction("Index", "Administrator"); } break;

                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Bunday foydalanuvchi mavjud emas");
                }
            }
            return RedirectToAction("Index", "Home");

         
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(WebApplication_brr_bmi1.Models.Users model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Users user = null;
                using (BazaContext db = new BazaContext())
                {
                    user = db.Users.Where(u => u.Login == model.Login &&
                    u.Password == model.Password).FirstOrDefault();
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    var rolee = user.RolesId;
                    BazaContext db = new BazaContext();
                    var nomi = db.Roles.Where(r => r.Id == rolee).First().Nomi;
                    var useridd = user.Id;

                   
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Bunday foydalanuvchi mavjud emas");
                }
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}