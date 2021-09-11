using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcCV.Models.entity;
using mvcCV.Models.Repositories;

namespace mvcCV.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim
        GenericRepositories<TBLİLETİŞİM> repo = new GenericRepositories<TBLİLETİŞİM>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}