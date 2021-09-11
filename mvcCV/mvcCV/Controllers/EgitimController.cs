using mvcCV.Models.entity;
using mvcCV.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcCV.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepositories<TBLEGİTİM> repo = new GenericRepositories<TBLEGİTİM>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBLEGİTİM p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
           
             var egitim = repo.Find(x=>x.ID==id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDüzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDüzenle(TBLEGİTİM t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDüzenle");
            }
            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.BASLIK = t.BASLIK;
            egitim.ALTBASLIK1 = t.ALTBASLIK1;
            egitim.ALTBASLIK2 = t.ALTBASLIK2;
            egitim.GNO = t.GNO;
            egitim.TARİH = t.TARİH;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}