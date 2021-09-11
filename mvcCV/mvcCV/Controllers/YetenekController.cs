using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcCV.Models.entity;
using mvcCV.Models.Repositories;

namespace mvcCV.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek

        GenericRepositories<TBLYETENEK> repo = new GenericRepositories<TBLYETENEK>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLYETENEK p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x=>x.ID== id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDüzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDüzenle(TBLYETENEK t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.YETENEK = t.YETENEK;
            y.ORAN = t.ORAN;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}