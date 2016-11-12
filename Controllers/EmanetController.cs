using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class EmanetController : Controller
    {
        kutuphaneEntities3 db = new kutuphaneEntities3();
        emanet_tbl emanet = new emanet_tbl();
        public ActionResult Index()
        {
            return View(db.emanet_tbl);
        }

        public ActionResult Emanet(String tc, String ad, String soyad, String isbn, String kitapadi, String yazar)
        {
            var list1 = db.kitap_tbl.Where(w => w.isbnno == isbn).ToList();
            String isbnkitap = list1[0].durum;
           
            if (list1.Count == 1)
            {
                if (isbnkitap=="aktif")
                {
                    
             
                String tarih = DateTime.Now.ToString("dd'.'MM'.'yyyy'.'HH'.'mm'.'ss");
                emanet.tc = tc;
                emanet.ad = ad;
                emanet.soyad = soyad;
                emanet.isbnno = isbn;
                emanet.kitapad = kitapadi;
                emanet.yazar = yazar;
                emanet.tarih = tarih;
                emanet.durum="pasif";

                kitap_tbl ayarlar = db.kitap_tbl.FirstOrDefault(x => x.isbnno == isbn);
                ayarlar.durum = "pasif";

                db.emanet_tbl.Add(emanet);
                db.SaveChanges();
                return RedirectToAction("Index", "Emanet");
                }

                return RedirectToAction("Index", "Hata");
            }

            return RedirectToAction("Index", "Hata");




        }

        public ActionResult Emanetal(String id)
        {
            emanet_tbl emanet = db.emanet_tbl.FirstOrDefault(x => x.isbnno == id);
            kitap_tbl emanet1 = db.kitap_tbl.FirstOrDefault(x => x.isbnno == id);
            emanet1.durum = "aktif";
            emanet.durum = "aktif";
            db.SaveChanges();
            return RedirectToAction("Index", "Emanet");

        }

    }
}
