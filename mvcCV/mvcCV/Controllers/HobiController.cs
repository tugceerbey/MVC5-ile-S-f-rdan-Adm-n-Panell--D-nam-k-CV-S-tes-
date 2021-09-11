using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcCV.Models.entity;
using mvcCV.Models.Repositories;

namespace mvcCV.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepositories<TBLÖDÜLLER> repo = new GenericRepositories<TBLÖDÜLLER>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }
        [HttpPost]
        public ActionResult Index(TBLÖDÜLLER h)
        {
            var t = repo.Find(x=>x.ID==1);
            t.ACIKLAMA1 = h.ACIKLAMA1;
            t.ACIKLAMA2 = h.ACIKLAMA2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}