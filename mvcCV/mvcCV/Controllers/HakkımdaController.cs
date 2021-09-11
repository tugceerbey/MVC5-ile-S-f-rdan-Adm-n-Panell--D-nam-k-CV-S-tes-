using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcCV.Models.entity;
using mvcCV.Models.Repositories;

namespace mvcCV.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        DBCVEntities db = new DBCVEntities();
        GenericRepositories<TBLHAKKIMDA> repo = new GenericRepositories<TBLHAKKIMDA>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkımda = repo.List();
            return View(hakkımda);
        }
        [HttpPost]
        public ActionResult Index(TBLHAKKIMDA p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.AD = p.AD;
            t.SOYAD = p.SOYAD;
            t.ADRES = p.ADRES;
            t.MAİL = p.MAİL;
            t.TELEFON = p.TELEFON;
            t.ACIKLAMA = p.ACIKLAMA;
            t.RESİM = p.RESİM;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}