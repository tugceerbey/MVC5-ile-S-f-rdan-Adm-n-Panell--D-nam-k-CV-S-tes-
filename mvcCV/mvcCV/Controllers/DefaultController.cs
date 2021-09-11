using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcCV.Models.entity;

namespace mvcCV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DBCVEntities db = new DBCVEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAKKIMDA.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyim = db.TBLDENEYİM.ToList();
            return PartialView(deneyim);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TBLEGİTİM.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TBLYETENEK.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TBLÖDÜLLER.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.TBLSERTİFİKA.ToList();
            return PartialView(sertifikalar);
        }
        [HttpPost]
        public PartialViewResult İletisim()
        {

            return PartialView();
        }
        [HttpGet]
        public PartialViewResult İletisim(TBLİLETİŞİM p)
        {
            p.TARİH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLİLETİŞİM.Add(p);
            db.SaveChanges();
            return PartialView();
        }
        public PartialViewResult SosyalMedya()
        {
            var medya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(medya);
        }
    }
}