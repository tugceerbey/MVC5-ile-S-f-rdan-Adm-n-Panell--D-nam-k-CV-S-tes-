using mvcCV.Models.entity;
using mvcCV.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcCV.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepositories repo = new DeneyimRepositories();

        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TBLDENEYİM p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            TBLDENEYİM t = repo.Find(x=>x.ID==id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TBLDENEYİM t=repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TBLDENEYİM p)
        {
            TBLDENEYİM t = repo.Find(x => x.ID == p.ID);
            t.BASLIK = p.BASLIK;
            t.ALTBASLIK = p.ALTBASLIK;
            t.TARİH = p.TARİH;
            t.ACIKLAMA = p.ACIKLAMA;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}