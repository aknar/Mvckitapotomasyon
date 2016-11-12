using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class AyarlarController : Controller
    {
        kutuphaneEntities3 db = new kutuphaneEntities3();

        admin_tbl ayarlar = new admin_tbl();
        //
        // GET: /Ayarlar/

        public ActionResult Index()
        {


            return View();
        }
        public ActionResult Ayarlar(String ad,String soyad)
        {
            admin_tbl ayarlar = db.admin_tbl.FirstOrDefault(x => x.id == 1);

            ayarlar.ad = ad;
            ayarlar.soyad = soyad;
            db.SaveChanges();

            return RedirectToAction("Index", "Login");

        }


    }
}
