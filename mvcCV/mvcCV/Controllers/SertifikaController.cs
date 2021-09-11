using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcCV.Models.entity;
using mvcCV.Models.Repositories;

namespace mvcCV.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika

        GenericRepositories<TBLSERTİFİKA> repo = new GenericRepositories<TBLSERTİFİKA>();

        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x=>x.ID==id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TBLSERTİFİKA t)
        {
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.ACIKLAMA = t.ACIKLAMA;
            sertifika.TARİH = t.TARİH;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(TBLSERTİFİKA p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x=>x.ID==id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }

    }
}