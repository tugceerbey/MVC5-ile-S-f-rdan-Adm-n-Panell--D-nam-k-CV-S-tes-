using mvcCV.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcCV.Models.entity;

namespace mvcCV.Controllers
{

   
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepositories<TBLADMİN> repo = new GenericRepositories<TBLADMİN>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TBLADMİN p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            TBLADMİN t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDüzenle(int id)
        {
            TBLADMİN t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminDüzenle(TBLADMİN p)
        {
            TBLADMİN t = repo.Find(x => x.ID == p.ID);
            t.KULLANICIADİ = p.KULLANICIADİ;
            t.SİFRE = p.SİFRE;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}