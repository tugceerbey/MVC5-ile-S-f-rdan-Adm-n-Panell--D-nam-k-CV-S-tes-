using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using mvcCV.Models.entity;
using mvcCV.Models.Repositories;

namespace mvcCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        GenericRepositories<TBLADMİN> repo = new GenericRepositories<TBLADMİN>();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBLADMİN p)
        {
            DBCVEntities db = new DBCVEntities();
            var bilgi = db.TBLADMİN.FirstOrDefault(x => x.KULLANICIADİ == p.KULLANICIADİ && x.SİFRE == p.SİFRE);
            if (bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KULLANICIADİ, false);
                Session["KULLANICIADİ"] = bilgi.KULLANICIADİ.ToString();
                return RedirectToAction("Index","Deneyim");

            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
       
    }
}