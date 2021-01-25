using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication_brr_bmi1.Models;
using PagedList.Mvc;
using PagedList;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace WebApplication_brr_bmi1.Controllers
{
    public class galeriyaController : Controller
    {
        //
        // GET: /galeriya/
        private BazaContext db = new BazaContext();

        // GET: /Xonadon/
        public ActionResult Index()
        {
            Sahifa s = new Sahifa();
            s.Xonadon = db.Xonadon.Include(x => x.Uy).Include(x => x.Uy.Tuman).Include(x => x.Uy.Tuman.Viloyat).Where(x => x.UyId != null && x.Holati==0).ToList();
            // var xonadon = db.Xonadon.Include(x => x.Uy);
            return View(s);
        }
      
        public ActionResult Buy(int?Id)
        {
            if(!User.Identity.IsAuthenticated)
            {
                ViewBag.Habar = "Siz ro'yhatdan o'tmagansiz!!";
            }
            else
            {
                var XaridorId = db.Users.Where(u => u.Login == User.Identity.Name).FirstOrDefault().XaridorId;
                return RedirectToAction("Olish", "galeriya", new {XaridorId=XaridorId,XonadonId=Id });
            }
            return View();
        }
        public ActionResult Olish(int?XaridorId,int?XonadonId)
        {
            ViewBag.x = XaridorId;
            ViewBag.j = XonadonId;
            Sahifa s = new Sahifa();
            s.Xonadon = db.Xonadon.Include(u => u.Uy).Include(u => u.Uy.Tuman).Where(x => x.Id == XonadonId).ToList();
            s.Xaridor = db.Xaridor.Include(u=>u.Tuman).Where(x => x.Id == XaridorId).ToList();
            s.tulov = db.tulov.ToList();
            return View(s);
        }
        [HttpPost]
        public ActionResult Olish(int? XaridorId, int? XonadonId,int?tulovId)
        {
            sotuv st = new sotuv();
            st.XonadonId = XonadonId;
            st.XaridorId = XaridorId;
            st.tulovId = tulovId;
            db.sotuv.Add(st);
            db.SaveChanges();
            Xonadon xon = db.Xonadon.Find(XonadonId);
            xon.Holati = 1;
            db.SaveChanges();
            var Xon = db.Xonadon.Include(x => x.Uy).Where(x => x.Id == XonadonId).FirstOrDefault();
            var xaridor = db.Xaridor.Include(x => x.Tuman).Where(x => x.Id == XaridorId).FirstOrDefault();
            var tul = db.tulov.Where(t => t.Id == tulovId).FirstOrDefault().Tulov_turi;
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            
            Chunk chunk = new Chunk("SHARTNOMA", FontFactory.GetFont("Arial", 30, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Familiya: "+xaridor.Familiya, FontFactory.GetFont("Times New Roman", 15, Font.NORMAL, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Ism: "+xaridor.Ismi, FontFactory.GetFont("Times New Roman", 15, Font.NORMAL, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Sharif: " + xaridor.Sharif, FontFactory.GetFont("Times New Roman", 15, Font.NORMAL, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Pasport ma'lumoti: " + xaridor.Pas_ser, FontFactory.GetFont("Times New Roman", 15, Font.NORMAL, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Manzili: " + xaridor.Tuman.Tuman_nomi+" tumani", FontFactory.GetFont("Times New Roman", 15, Font.BOLD, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Narxi: " + Xon.Narxi, FontFactory.GetFont("Times New Roman", 15, Font.NORMAL, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Xonalar soni: " + Xon.Xonalar_soni+"xona", FontFactory.GetFont("Times New Roman", 15, Font.NORMAL, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Nechanchi qavat: " + Xon.Nechnchi_qavat+"-qavat", FontFactory.GetFont("Times New Roman", 15, Font.NORMAL, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("Uy manzili: " + Xon.Uy.Manzil, FontFactory.GetFont("Times New Roman", 15, Font.NORMAL, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));
            chunk = new Chunk("To'lov turi: " + tul, FontFactory.GetFont("Times New Roman", 15, Font.NORMAL, BaseColor.BLACK));
            pdfDoc.Add(new Paragraph(chunk));

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Hisobot.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
            return RedirectToAction("Index", "Home");
        }

	}
    
}